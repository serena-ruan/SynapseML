import uuid
import logging

from GatewayUtils import GatewayUtils

class PythonEntryPoint(GatewayUtils):
    def __init__(self):
        self.pool = {}
    
    # Only support setParam method on objects to make this function clean
    # TODO: update python class loader (java_params_patch.py)
    def createObject(self, class_name):
        uid = class_name + "_" + str(uuid.uuid4())[-12:]
        self.pool[uid] = eval(class_name+"()")
        self.gateway.jvm.System.out.println(uid)
        return uid
    
    # def callMethod(self, uid, method_name, **kwargs):
    #     obj = self.pool[uid]
    #     logging.warning(f"----------uid: {uid}")
    #     self.gateway.jvm.System.out.println(uid)
    #     logging.warning(f"----------kwargs: {kwargs}")
    #     self.gateway.jvm.System.out.println(kwargs)
    #     func = getattr(obj, method_name)
    #     logging.warning(f"----------func: {func}")
    #     return func(**kwargs)
    
    # py4j.clientserver.py _call_proxy method uses *args
    def callMethod(self, uid, method_name, *args):
        obj = self.pool[uid]
        logging.warning(f"----------uid: {uid}")
        self.gateway.jvm.System.out.println(uid)
        logging.warning(f"*********args: {args}")
        self.gateway.jvm.System.out.println(args)
        func = getattr(obj, method_name)
        logging.warning(f"----------func: {func}")
        if len(args) > 1:
            raise Exception(f"Only accept kwargs here, {args} received")
        elif len(args) == 1:
            kwargs = args[0]
            return func(**kwargs)
        else:
            return func()

    def getObject(self, uid):
        return self.pool[uid]

    class Java:
        implements = ["org.apache.spark.dl.IPythonEntryPoint"]

class SimpleHello:
    def __init__(self):
        self.prefix = "Hello "
    
    def sayHello(self, name, greetings):
        print(self.prefix + name + ", " + greetings)

class PythonEntryPointHelper:

    @classmethod
    def startPyPort(cls, secret):
        import os
        from py4j.clientserver import ClientServer, JavaParameters, PythonParameters

        python_entry_point = PythonEntryPoint()
        print(f"Create PythonEntryPoint object")
        java_parameters = JavaParameters(auth_token=secret, auto_convert=True)
        python_parameters = PythonParameters(auth_token=secret)
        gateway = ClientServer(
            java_parameters=java_parameters,
            python_parameters=python_parameters,
            python_server_entry_point=python_entry_point
        )
        
        python_entry_point.setGateway(gateway)
        print(f"PYSPARK_GATEWAY_PORT: {str(java_parameters.port)}")
        print(f"auth token: {gateway.gateway_parameters.auth_token}")
        print(f"Service started at port: {gateway.python_parameters.port}")


if __name__ == "__main__":
    import sys

    PythonEntryPointHelper.startPyPort(str(sys.argv[1]))
