(self.webpackChunksynapseml=self.webpackChunksynapseml||[]).push([[150],{3905:function(e,a,t){"use strict";t.d(a,{Zo:function(){return i},kt:function(){return d}});var n=t(7294);function l(e,a,t){return a in e?Object.defineProperty(e,a,{value:t,enumerable:!0,configurable:!0,writable:!0}):e[a]=t,e}function s(e,a){var t=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);a&&(n=n.filter((function(a){return Object.getOwnPropertyDescriptor(e,a).enumerable}))),t.push.apply(t,n)}return t}function r(e){for(var a=1;a<arguments.length;a++){var t=null!=arguments[a]?arguments[a]:{};a%2?s(Object(t),!0).forEach((function(a){l(e,a,t[a])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(t)):s(Object(t)).forEach((function(a){Object.defineProperty(e,a,Object.getOwnPropertyDescriptor(t,a))}))}return e}function o(e,a){if(null==e)return{};var t,n,l=function(e,a){if(null==e)return{};var t,n,l={},s=Object.keys(e);for(n=0;n<s.length;n++)t=s[n],a.indexOf(t)>=0||(l[t]=e[t]);return l}(e,a);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(n=0;n<s.length;n++)t=s[n],a.indexOf(t)>=0||Object.prototype.propertyIsEnumerable.call(e,t)&&(l[t]=e[t])}return l}var m=n.createContext({}),p=function(e){var a=n.useContext(m),t=a;return e&&(t="function"==typeof e?e(a):r(r({},a),e)),t},i=function(e){var a=p(e.components);return n.createElement(m.Provider,{value:a},e.children)},c={inlineCode:"code",wrapper:function(e){var a=e.children;return n.createElement(n.Fragment,{},a)}},u=n.forwardRef((function(e,a){var t=e.components,l=e.mdxType,s=e.originalType,m=e.parentName,i=o(e,["components","mdxType","originalType","parentName"]),u=p(t),d=l,y=u["".concat(m,".").concat(d)]||u[d]||c[d]||s;return t?n.createElement(y,r(r({ref:a},i),{},{components:t})):n.createElement(y,r({ref:a},i))}));function d(e,a){var t=arguments,l=a&&a.mdxType;if("string"==typeof e||l){var s=t.length,r=new Array(s);r[0]=u;var o={};for(var m in a)hasOwnProperty.call(a,m)&&(o[m]=a[m]);o.originalType=e,o.mdxType="string"==typeof e?e:l,r[1]=o;for(var p=2;p<s;p++)r[p]=t[p];return n.createElement.apply(null,r)}return n.createElement.apply(null,t)}u.displayName="MDXCreateElement"},1332:function(e,a,t){"use strict";var n=t(7294);a.Z=function(e){var a=e.children,t=e.hidden,l=e.className;return n.createElement("div",{role:"tabpanel",hidden:t,className:l},a)}},5386:function(e,a,t){"use strict";t.d(a,{Z:function(){return c}});var n=t(7294),l=t(8578);var s=function(){var e=(0,n.useContext)(l.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},r=t(6010),o="tabItem_2kG2",m="tabItemActive_3NDg";var p=37,i=39;var c=function(e){var a=e.lazy,t=e.block,l=e.defaultValue,c=e.values,u=e.groupId,d=e.className,y=s(),f=y.tabGroupChoices,b=y.setTabGroupChoices,g=(0,n.useState)(l),x=g[0],v=g[1],h=n.Children.toArray(e.children),T=[];if(null!=u){var k=f[u];null!=k&&k!==x&&c.some((function(e){return e.value===k}))&&v(k)}var N=function(e){var a=e.currentTarget,t=T.indexOf(a),n=c[t].value;v(n),null!=u&&(b(u,n),setTimeout((function(){var e,t,n,l,s,r,o,p;(e=a.getBoundingClientRect(),t=e.top,n=e.left,l=e.bottom,s=e.right,r=window,o=r.innerHeight,p=r.innerWidth,t>=0&&s<=p&&l<=o&&n>=0)||(a.scrollIntoView({block:"center",behavior:"smooth"}),a.classList.add(m),setTimeout((function(){return a.classList.remove(m)}),2e3))}),150))},M=function(e){var a,t;switch(e.keyCode){case i:var n=T.indexOf(e.target)+1;t=T[n]||T[0];break;case p:var l=T.indexOf(e.target)-1;t=T[l]||T[T.length-1]}null==(a=t)||a.focus()};return n.createElement("div",{className:"tabs-container"},n.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,r.Z)("tabs",{"tabs--block":t},d)},c.map((function(e){var a=e.value,t=e.label;return n.createElement("li",{role:"tab",tabIndex:x===a?0:-1,"aria-selected":x===a,className:(0,r.Z)("tabs__item",o,{"tabs__item--active":x===a}),key:a,ref:function(e){return T.push(e)},onKeyDown:M,onFocus:N,onClick:N},t)}))),a?(0,n.cloneElement)(h.filter((function(e){return e.props.value===x}))[0],{className:"margin-vert--md"}):n.createElement("div",{className:"margin-vert--md"},h.map((function(e,a){return(0,n.cloneElement)(e,{key:a,hidden:e.props.value!==x})}))))}},8578:function(e,a,t){"use strict";var n=(0,t(7294).createContext)(void 0);a.Z=n},1989:function(e,a,t){"use strict";var n=t(7294),l=t(2263);a.Z=function(e){var a=e.className,t=e.py,s=e.scala,r=e.sourceLink,o=(0,l.Z)().siteConfig.customFields.version,m="https://mmlspark.blob.core.windows.net/docs/"+o+"/pyspark/"+t,p="https://mmlspark.blob.core.windows.net/docs/"+o+"/scala/"+s;return n.createElement("table",null,n.createElement("tbody",null,n.createElement("tr",null,n.createElement("td",null,n.createElement("strong",null,"Python API: "),n.createElement("a",{href:m},a)),n.createElement("td",null,n.createElement("strong",null,"Scala API: "),n.createElement("a",{href:p},a)),n.createElement("td",null,n.createElement("strong",null,"Source: "),n.createElement("a",{href:r},a)))))}},1487:function(e,a,t){"use strict";t.r(a),t.d(a,{frontMatter:function(){return i},contentTitle:function(){return c},metadata:function(){return u},toc:function(){return d},default:function(){return f}});var n=t(2122),l=t(9756),s=(t(7294),t(3905)),r=t(5386),o=t(1332),m=t(1989),p=["components"],i={},c=void 0,u={unversionedId:"documentation/transformers/core/_Explainers",id:"documentation/transformers/core/_Explainers",isDocsHomePage:!1,title:"_Explainers",description:"\x3c!--",source:"@site/docs/documentation/transformers/core/_Explainers.md",sourceDirName:"documentation/transformers/core",slug:"/documentation/transformers/core/_Explainers",permalink:"/SynapseML/docs/next/documentation/transformers/core/_Explainers",version:"current",frontMatter:{}},d=[{value:"Explainers",id:"explainers",children:[{value:"ImageLIME",id:"imagelime",children:[]},{value:"ImageSHAP",id:"imageshap",children:[]},{value:"TabularLIME",id:"tabularlime",children:[]},{value:"TabularSHAP",id:"tabularshap",children:[]},{value:"TextLIME",id:"textlime",children:[]},{value:"TextSHAP",id:"textshap",children:[]},{value:"VectorLIME",id:"vectorlime",children:[]},{value:"VectorSHAP",id:"vectorshap",children:[]}]}],y={toc:d};function f(e){var a=e.components,t=(0,l.Z)(e,p);return(0,s.kt)("wrapper",(0,n.Z)({},y,t,{components:a,mdxType:"MDXLayout"}),(0,s.kt)("h2",{id:"explainers"},"Explainers"),(0,s.kt)("h3",{id:"imagelime"},"ImageLIME"),(0,s.kt)(r.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(o.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.explainers import *\nfrom synapse.ml.onnx import ONNXModel\n\nmodel = ONNXModel()\n\nlime = (ImageLIME()\n    .setModel(model)\n    .setOutputCol("weights")\n    .setInputCol("image")\n    .setCellSize(150.0)\n    .setModifier(50.0)\n    .setNumSamples(500)\n    .setTargetCol("probability")\n    .setTargetClassesCol("top2pred")\n    .setSamplingFraction(0.7))\n'))),(0,s.kt)(o.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.explainers._\nimport com.microsoft.azure.synapse.ml.onnx._\nimport spark.implicits._\n\nval model = (new ONNXModel())\n\nval lime = (new ImageLIME()\n    .setModel(model)\n    .setOutputCol("weights")\n    .setInputCol("image")\n    .setCellSize(150.0)\n    .setModifier(50.0)\n    .setNumSamples(500)\n    .setTargetCol("probability")\n    .setTargetClassesCol("top2pred")\n    .setSamplingFraction(0.7))\n')))),(0,s.kt)(m.Z,{className:"ImageLIME",py:"synapse.ml.explainers.html#module-synapse.ml.explainers.ImageLIME",scala:"com/microsoft/azure/synapse/ml/explainers/ImageLIME.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/explainers/ImageLIME.scala",mdxType:"DocTable"}),(0,s.kt)("h3",{id:"imageshap"},"ImageSHAP"),(0,s.kt)(r.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(o.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.explainers import *\nfrom synapse.ml.onnx import ONNXModel\n\nmodel = ONNXModel()\n\nshap = (\n    ImageSHAP()\n    .setModel(model)\n    .setOutputCol("shaps")\n    .setSuperpixelCol("superpixels")\n    .setInputCol("image")\n    .setCellSize(150.0)\n    .setModifier(50.0)\n    .setNumSamples(500)\n    .setTargetCol("probability")\n    .setTargetClassesCol("top2pred")\n)\n'))),(0,s.kt)(o.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.explainers._\nimport com.microsoft.azure.synapse.ml.onnx._\nimport spark.implicits._\n\nval model = (new ONNXModel())\n\nval shap = (new ImageSHAP()\n    .setModel(model)\n    .setOutputCol("shaps")\n    .setSuperpixelCol("superpixels")\n    .setInputCol("image")\n    .setCellSize(150.0)\n    .setModifier(50.0)\n    .setNumSamples(500)\n    .setTargetCol("probability")\n    .setTargetClassesCol("top2pred")\n))\n')))),(0,s.kt)(m.Z,{className:"ImageSHAP",py:"synapse.ml.explainers.html#module-synapse.ml.explainers.ImageSHAP",scala:"com/microsoft/azure/synapse/ml/explainers/ImageSHAP.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/explainers/ImageSHAP.scala",mdxType:"DocTable"}),(0,s.kt)("h3",{id:"tabularlime"},"TabularLIME"),(0,s.kt)(r.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(o.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.explainers import *\nfrom synapse.ml.onnx import ONNXModel\n\nmodel = ONNXModel()\ndata = spark.createDataFrame([\n    (-6.0, 0),\n    (-5.0, 0),\n    (5.0, 1),\n    (6.0, 1)\n], ["col1", "label"])\n\nlime = (TabularLIME()\n    .setModel(model)\n    .setInputCols(["col1"])\n    .setOutputCol("weights")\n    .setBackgroundData(data)\n    .setKernelWidth(0.001)\n    .setNumSamples(1000)\n    .setTargetCol("probability")\n    .setTargetClasses([0, 1]))\n'))),(0,s.kt)(o.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.explainers._\nimport com.microsoft.azure.synapse.ml.onnx._\nimport spark.implicits._\n\nval model = (new ONNXModel())\nval data = Seq(\n  (-6.0, 0),\n  (-5.0, 0),\n  (5.0, 1),\n  (6.0, 1)\n).toDF("col1", "label")\n\nval lime = (new TabularLIME()\n    .setInputCols(Array("col1"))\n    .setOutputCol("weights")\n    .setBackgroundData(data)\n    .setKernelWidth(0.001)\n    .setNumSamples(1000)\n    .setModel(model)\n    .setTargetCol("probability")\n    .setTargetClasses(Array(0, 1)))\n')))),(0,s.kt)(m.Z,{className:"TabularLIME",py:"synapse.ml.explainers.html#module-synapse.ml.explainers.TabularLIME",scala:"com/microsoft/azure/synapse/ml/explainers/TabularLIME.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/explainers/TabularLIME.scala",mdxType:"DocTable"}),(0,s.kt)("h3",{id:"tabularshap"},"TabularSHAP"),(0,s.kt)(r.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(o.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.explainers import *\nfrom synapse.ml.onnx import ONNXModel\n\nmodel = ONNXModel()\ndata = spark.createDataFrame([\n    (-5.0, "a", -5.0, 0),\n    (-5.0, "b", -5.0, 0),\n    (5.0, "a", 5.0, 1),\n    (5.0, "b", 5.0, 1)\n]*100, ["col1", "label"])\n\nshap = (TabularSHAP()\n    .setInputCols(["col1", "col2", "col3"])\n    .setOutputCol("shapValues")\n    .setBackgroundData(data)\n    .setNumSamples(1000)\n    .setModel(model)\n    .setTargetCol("probability")\n    .setTargetClasses([1]))\n'))),(0,s.kt)(o.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.explainers._\nimport com.microsoft.azure.synapse.ml.onnx._\nimport spark.implicits._\n\nval model = (new ONNXModel())\nval data = (1 to 100).flatMap(_ => Seq(\n    (-5d, "a", -5d, 0),\n    (-5d, "b", -5d, 0),\n    (5d, "a", 5d, 1),\n    (5d, "b", 5d, 1)\n  )).toDF("col1", "col2", "col3", "label")\n\nval shap = (new TabularSHAP()\n    .setInputCols(Array("col1", "col2", "col3"))\n    .setOutputCol("shapValues")\n    .setBackgroundData(data)\n    .setNumSamples(1000)\n    .setModel(model)\n    .setTargetCol("probability")\n    .setTargetClasses(Array(1)))\n')))),(0,s.kt)(m.Z,{className:"TabularSHAP",py:"synapse.ml.explainers.html#module-synapse.ml.explainers.TabularSHAP",scala:"com/microsoft/azure/synapse/ml/explainers/TabularSHAP.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/explainers/TabularSHAP.scala",mdxType:"DocTable"}),(0,s.kt)("h3",{id:"textlime"},"TextLIME"),(0,s.kt)(r.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(o.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.explainers import *\nfrom synapse.ml.onnx import ONNXModel\n\nmodel = ONNXModel()\n\nlime = (TextLIME()\n    .setModel(model)\n    .setInputCol("text")\n    .setTargetCol("prob")\n    .setTargetClasses([1])\n    .setOutputCol("weights")\n    .setTokensCol("tokens")\n    .setSamplingFraction(0.7)\n    .setNumSamples(1000))\n'))),(0,s.kt)(o.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.explainers._\nimport com.microsoft.azure.synapse.ml.onnx._\nimport spark.implicits._\n\nval model = (new ONNXModel())\n\nval lime = (new TextLIME()\n    .setModel(model)\n    .setInputCol("text")\n    .setTargetCol("prob")\n    .setTargetClasses(Array(1))\n    .setOutputCol("weights")\n    .setTokensCol("tokens")\n    .setSamplingFraction(0.7)\n    .setNumSamples(1000))\n')))),(0,s.kt)(m.Z,{className:"TextLIME",py:"synapse.ml.explainers.html#module-synapse.ml.explainers.TextLIME",scala:"com/microsoft/azure/synapse/ml/explainers/TextLIME.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/explainers/TextLIME.scala",mdxType:"DocTable"}),(0,s.kt)("h3",{id:"textshap"},"TextSHAP"),(0,s.kt)(r.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(o.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.explainers import *\nfrom synapse.ml.onnx import ONNXModel\n\nmodel = ONNXModel()\n\nshap = (TextSHAP()\n    .setModel(model)\n    .setInputCol("text")\n    .setTargetCol("prob")\n    .setTargetClasses([1])\n    .setOutputCol("weights")\n    .setTokensCol("tokens")\n    .setNumSamples(1000))\n'))),(0,s.kt)(o.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.explainers._\nimport com.microsoft.azure.synapse.ml.onnx._\nimport spark.implicits._\n\nval model = (new ONNXModel())\n\nval shap = (new TextSHAP()\n    .setModel(model)\n    .setInputCol("text")\n    .setTargetCol("prob")\n    .setTargetClasses(Array(1))\n    .setOutputCol("weights")\n    .setTokensCol("tokens")\n    .setNumSamples(1000))\n')))),(0,s.kt)(m.Z,{className:"TextSHAP",py:"synapse.ml.explainers.html#module-synapse.ml.explainers.TextSHAP",scala:"com/microsoft/azure/synapse/ml/explainers/TextSHAP.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/explainers/TextSHAP.scala",mdxType:"DocTable"}),(0,s.kt)("h3",{id:"vectorlime"},"VectorLIME"),(0,s.kt)(r.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(o.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.explainers import *\nfrom synapse.ml.onnx import ONNXModel\n\nmodel = ONNXModel()\n\ndf = spark.createDataframe([\n  ([0.2729799734928408, -0.4637273304253777, 1.565593782147994], 4.541185129673482),\n  ([1.9511879801376864, 1.495644437589599, -0.4667847796501322], 0.19526424470709836)\n])\n\nlime = (VectorLIME()\n    .setModel(model)\n    .setBackgroundData(df)\n    .setInputCol("features")\n    .setTargetCol("label")\n    .setOutputCol("weights")\n    .setNumSamples(1000))\n'))),(0,s.kt)(o.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.explainers._\nimport spark.implicits._\nimport breeze.linalg.{*, DenseMatrix => BDM}\nimport breeze.stats.distributions.Rand\nimport org.apache.spark.ml.linalg.Vectors\nimport org.apache.spark.ml.regression.LinearRegression\n\nval d1 = 3\nval d2 = 1\nval coefficients: BDM[Double] = new BDM(d1, d2, Array(1.0, -1.0, 2.0))\n\nval df = {\n    val nRows = 100\n    val intercept: Double = math.random()\n\n    val x: BDM[Double] = BDM.rand(nRows, d1, Rand.gaussian)\n    val y = x * coefficients + intercept\n\n    val xRows = x(*, ::).iterator.toSeq.map(dv => Vectors.dense(dv.toArray))\n    val yRows = y(*, ::).iterator.toSeq.map(dv => dv(0))\n    xRows.zip(yRows).toDF("features", "label")\n  }\n\nval model: LinearRegressionModel = new LinearRegression().fit(df)\n\nval lime = (new VectorLIME()\n    .setModel(model)\n    .setBackgroundData(df)\n    .setInputCol("features")\n    .setTargetCol(model.getPredictionCol)\n    .setOutputCol("weights")\n    .setNumSamples(1000))\n')))),(0,s.kt)(m.Z,{className:"VectorLIME",py:"synapse.ml.explainers.html#module-synapse.ml.explainers.VectorLIME",scala:"com/microsoft/azure/synapse/ml/explainers/VectorLIME.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/explainers/VectorLIME.scala",mdxType:"DocTable"}),(0,s.kt)("h3",{id:"vectorshap"},"VectorSHAP"),(0,s.kt)(r.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(o.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.explainers import *\nfrom synapse.ml.onnx import ONNXModel\n\nmodel = ONNXModel()\n\nshap = (VectorSHAP()\n    .setModel(model)\n    .setInputCol("text")\n    .setTargetCol("prob")\n    .setTargetClasses([1])\n    .setOutputCol("weights")\n    .setTokensCol("tokens")\n    .setNumSamples(1000))\n'))),(0,s.kt)(o.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.explainers._\nimport spark.implicits._\nimport breeze.linalg.{*, DenseMatrix => BDM}\nimport breeze.stats.distributions.RandBasis\nimport org.apache.spark.ml.classification.LogisticRegression\nimport org.apache.spark.ml.linalg.Vectors\n\nval randBasis = RandBasis.withSeed(123)\nval m: BDM[Double] = BDM.rand[Double](1000, 5, randBasis.gaussian)\nval l: BDV[Double] = m(*, ::).map {\n    row =>\n      if (row(2) + row(3) > 0.5) 1d else 0d\n  }\nval data = m(*, ::).iterator.zip(l.valuesIterator).map {\n    case (f, l) => (f.toSpark, l)\n  }.toSeq.toDF("features", "label")\n\nval model = new LogisticRegression()\n    .setFeaturesCol("features")\n    .setLabelCol("label")\n    .fit(data)\n\nval shap = (new VectorSHAP()\n    .setInputCol("features")\n    .setOutputCol("shapValues")\n    .setBackgroundData(data)\n    .setNumSamples(1000)\n    .setModel(model)\n    .setTargetCol("probability")\n    .setTargetClasses(Array(1))\n\nval infer = Seq(\n    Tuple1(Vectors.dense(1d, 1d, 1d, 1d, 1d))\n  ) toDF "features"\nval predicted = model.transform(infer)\ndisplay(shap.transform(predicted))\n')))),(0,s.kt)(m.Z,{className:"VectorSHAP",py:"synapse.ml.explainers.html#module-synapse.ml.explainers.VectorSHAP",scala:"com/microsoft/azure/synapse/ml/explainers/VectorSHAP.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/explainers/VectorSHAP.scala",mdxType:"DocTable"}))}f.isMDXComponent=!0},6010:function(e,a,t){"use strict";function n(e){var a,t,l="";if("string"==typeof e||"number"==typeof e)l+=e;else if("object"==typeof e)if(Array.isArray(e))for(a=0;a<e.length;a++)e[a]&&(t=n(e[a]))&&(l&&(l+=" "),l+=t);else for(a in e)e[a]&&(l&&(l+=" "),l+=a);return l}function l(){for(var e,a,t=0,l="";t<arguments.length;)(e=arguments[t++])&&(a=n(e))&&(l&&(l+=" "),l+=a);return l}t.d(a,{Z:function(){return l}})}}]);