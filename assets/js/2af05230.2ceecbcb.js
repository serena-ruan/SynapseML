(self.webpackChunksynapseml=self.webpackChunksynapseml||[]).push([[2875],{3905:function(e,n,a){"use strict";a.d(n,{Zo:function(){return c},kt:function(){return d}});var t=a(7294);function r(e,n,a){return n in e?Object.defineProperty(e,n,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[n]=a,e}function o(e,n){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var t=Object.getOwnPropertySymbols(e);n&&(t=t.filter((function(n){return Object.getOwnPropertyDescriptor(e,n).enumerable}))),a.push.apply(a,t)}return a}function s(e){for(var n=1;n<arguments.length;n++){var a=null!=arguments[n]?arguments[n]:{};n%2?o(Object(a),!0).forEach((function(n){r(e,n,a[n])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):o(Object(a)).forEach((function(n){Object.defineProperty(e,n,Object.getOwnPropertyDescriptor(a,n))}))}return e}function l(e,n){if(null==e)return{};var a,t,r=function(e,n){if(null==e)return{};var a,t,r={},o=Object.keys(e);for(t=0;t<o.length;t++)a=o[t],n.indexOf(a)>=0||(r[a]=e[a]);return r}(e,n);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(t=0;t<o.length;t++)a=o[t],n.indexOf(a)>=0||Object.prototype.propertyIsEnumerable.call(e,a)&&(r[a]=e[a])}return r}var i=t.createContext({}),m=function(e){var n=t.useContext(i),a=n;return e&&(a="function"==typeof e?e(n):s(s({},n),e)),a},c=function(e){var n=m(e.components);return t.createElement(i.Provider,{value:n},e.children)},u={inlineCode:"code",wrapper:function(e){var n=e.children;return t.createElement(t.Fragment,{},n)}},p=t.forwardRef((function(e,n){var a=e.components,r=e.mdxType,o=e.originalType,i=e.parentName,c=l(e,["components","mdxType","originalType","parentName"]),p=m(a),d=r,f=p["".concat(i,".").concat(d)]||p[d]||u[d]||o;return a?t.createElement(f,s(s({ref:n},c),{},{components:a})):t.createElement(f,s({ref:n},c))}));function d(e,n){var a=arguments,r=n&&n.mdxType;if("string"==typeof e||r){var o=a.length,s=new Array(o);s[0]=p;var l={};for(var i in n)hasOwnProperty.call(n,i)&&(l[i]=n[i]);l.originalType=e,l.mdxType="string"==typeof e?e:r,s[1]=l;for(var m=2;m<o;m++)s[m]=a[m];return t.createElement.apply(null,s)}return t.createElement.apply(null,a)}p.displayName="MDXCreateElement"},1332:function(e,n,a){"use strict";var t=a(7294);n.Z=function(e){var n=e.children,a=e.hidden,r=e.className;return t.createElement("div",{role:"tabpanel",hidden:a,className:r},n)}},5386:function(e,n,a){"use strict";a.d(n,{Z:function(){return u}});var t=a(7294),r=a(8578);var o=function(){var e=(0,t.useContext)(r.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},s=a(6010),l="tabItem_2kG2",i="tabItemActive_3NDg";var m=37,c=39;var u=function(e){var n=e.lazy,a=e.block,r=e.defaultValue,u=e.values,p=e.groupId,d=e.className,f=o(),y=f.tabGroupChoices,b=f.setTabGroupChoices,v=(0,t.useState)(r),g=v[0],h=v[1],M=t.Children.toArray(e.children),k=[];if(null!=p){var T=y[p];null!=T&&T!==g&&u.some((function(e){return e.value===T}))&&h(T)}var C=function(e){var n=e.currentTarget,a=k.indexOf(n),t=u[a].value;h(t),null!=p&&(b(p,t),setTimeout((function(){var e,a,t,r,o,s,l,m;(e=n.getBoundingClientRect(),a=e.top,t=e.left,r=e.bottom,o=e.right,s=window,l=s.innerHeight,m=s.innerWidth,a>=0&&o<=m&&r<=l&&t>=0)||(n.scrollIntoView({block:"center",behavior:"smooth"}),n.classList.add(i),setTimeout((function(){return n.classList.remove(i)}),2e3))}),150))},_=function(e){var n,a;switch(e.keyCode){case c:var t=k.indexOf(e.target)+1;a=k[t]||k[0];break;case m:var r=k.indexOf(e.target)-1;a=k[r]||k[k.length-1]}null==(n=a)||n.focus()};return t.createElement("div",{className:"tabs-container"},t.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,s.Z)("tabs",{"tabs--block":a},d)},u.map((function(e){var n=e.value,a=e.label;return t.createElement("li",{role:"tab",tabIndex:g===n?0:-1,"aria-selected":g===n,className:(0,s.Z)("tabs__item",l,{"tabs__item--active":g===n}),key:n,ref:function(e){return k.push(e)},onKeyDown:_,onFocus:C,onClick:C},a)}))),n?(0,t.cloneElement)(M.filter((function(e){return e.props.value===g}))[0],{className:"margin-vert--md"}):t.createElement("div",{className:"margin-vert--md"},M.map((function(e,n){return(0,t.cloneElement)(e,{key:n,hidden:e.props.value!==g})}))))}},8578:function(e,n,a){"use strict";var t=(0,a(7294).createContext)(void 0);n.Z=t},1989:function(e,n,a){"use strict";var t=a(7294),r=a(2263);n.Z=function(e){var n=e.className,a=e.py,o=e.scala,s=e.sourceLink,l=(0,r.Z)().siteConfig.customFields.version,i="https://mmlspark.blob.core.windows.net/docs/"+l+"/pyspark/"+a,m="https://mmlspark.blob.core.windows.net/docs/"+l+"/scala/"+o;return t.createElement("table",null,t.createElement("tbody",null,t.createElement("tr",null,t.createElement("td",null,t.createElement("strong",null,"Python API: "),t.createElement("a",{href:i},n)),t.createElement("td",null,t.createElement("strong",null,"Scala API: "),t.createElement("a",{href:m},n)),t.createElement("td",null,t.createElement("strong",null,"Source: "),t.createElement("a",{href:s},n)))))}},5207:function(e,n,a){"use strict";a.r(n),a.d(n,{frontMatter:function(){return c},contentTitle:function(){return u},metadata:function(){return p},toc:function(){return d},default:function(){return y}});var t=a(2122),r=a(9756),o=(a(7294),a(3905)),s=a(5386),l=a(1332),i=a(1989),m=["components"],c={},u=void 0,p={unversionedId:"documentation/estimators/core/_AutoML",id:"version-0.9.1/documentation/estimators/core/_AutoML",isDocsHomePage:!1,title:"_AutoML",description:"\x3c!--",source:"@site/versioned_docs/version-0.9.1/documentation/estimators/core/_AutoML.md",sourceDirName:"documentation/estimators/core",slug:"/documentation/estimators/core/_AutoML",permalink:"/SynapseML/docs/documentation/estimators/core/_AutoML",version:"0.9.1",frontMatter:{}},d=[{value:"AutoML",id:"automl",children:[{value:"FindBestModel",id:"findbestmodel",children:[]},{value:"TuneHyperparameters",id:"tunehyperparameters",children:[]}]}],f={toc:d};function y(e){var n=e.components,a=(0,r.Z)(e,m);return(0,o.kt)("wrapper",(0,t.Z)({},f,a,{components:n,mdxType:"MDXLayout"}),(0,o.kt)("h2",{id:"automl"},"AutoML"),(0,o.kt)("h3",{id:"findbestmodel"},"FindBestModel"),(0,o.kt)(s.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,o.kt)(l.Z,{value:"py",mdxType:"TabItem"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.automl import *\nfrom synapse.ml.train import *\nfrom pyspark.ml.classification import RandomForestClassifier\n\ndf = (spark.createDataFrame([\n    (0, 2, 0.50, 0.60, 0),\n    (1, 3, 0.40, 0.50, 1),\n    (0, 4, 0.78, 0.99, 2),\n    (1, 5, 0.12, 0.34, 3),\n    (0, 1, 0.50, 0.60, 0),\n    (1, 3, 0.40, 0.50, 1),\n    (0, 3, 0.78, 0.99, 2),\n    (1, 4, 0.12, 0.34, 3),\n    (0, 0, 0.50, 0.60, 0),\n    (1, 2, 0.40, 0.50, 1),\n    (0, 3, 0.78, 0.99, 2),\n    (1, 4, 0.12, 0.34, 3)\n], ["Label", "col1", "col2", "col3", "col4"]))\n\n# mocking models\nrandomForestClassifier = (TrainClassifier()\n      .setModel(RandomForestClassifier()\n        .setMaxBins(32)\n        .setMaxDepth(5)\n        .setMinInfoGain(0.0)\n        .setMinInstancesPerNode(1)\n        .setNumTrees(20)\n        .setSubsamplingRate(1.0)\n        .setSeed(0))\n      .setFeaturesCol("mlfeatures")\n      .setLabelCol("Label"))\nmodel = randomForestClassifier.fit(df)\n\nfindBestModel = (FindBestModel()\n  .setModels([model, model])\n  .setEvaluationMetric("accuracy"))\nbestModel = findBestModel.fit(df)\ndisplay(bestModel.transform(df))\n'))),(0,o.kt)(l.Z,{value:"scala",mdxType:"TabItem"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.automl._\nimport com.microsoft.azure.synapse.ml.train._\nimport spark.implicits._\nimport org.apache.spark.ml.Transformer\n\nval df = (Seq(\n      (0, 2, 0.50, 0.60, 0),\n      (1, 3, 0.40, 0.50, 1),\n      (0, 4, 0.78, 0.99, 2),\n      (1, 5, 0.12, 0.34, 3),\n      (0, 1, 0.50, 0.60, 0),\n      (1, 3, 0.40, 0.50, 1),\n      (0, 3, 0.78, 0.99, 2),\n      (1, 4, 0.12, 0.34, 3),\n      (0, 0, 0.50, 0.60, 0),\n      (1, 2, 0.40, 0.50, 1),\n      (0, 3, 0.78, 0.99, 2),\n      (1, 4, 0.12, 0.34, 3)\n  ).toDF("Label", "col1", "col2", "col3", "col4"))\n\n// mocking models\nval randomForestClassifier = (new TrainClassifier()\n      .setModel(\n        new RandomForestClassifier()\n        .setMaxBins(32)\n        .setMaxDepth(5)\n        .setMinInfoGain(0.0)\n        .setMinInstancesPerNode(1)\n        .setNumTrees(20)\n        .setSubsamplingRate(1.0)\n        .setSeed(0L))\n      .setFeaturesCol("mlfeatures")\n      .setLabelCol("Label"))\nval model = randomForestClassifier.fit(df)\n\nval findBestModel = (new FindBestModel()\n  .setModels(Array(model.asInstanceOf[Transformer], model.asInstanceOf[Transformer]))\n  .setEvaluationMetric("accuracy"))\nval bestModel = findBestModel.fit(df)\ndisplay(bestModel.transform(df))\n')))),(0,o.kt)(i.Z,{className:"FindBestModel",py:"synapse.ml.automl.html#module-synapse.ml.automl.FindBestModel",scala:"com/microsoft/azure/synapse/ml/automl/FindBestModel.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/automl/FindBestModel.scala",mdxType:"DocTable"}),(0,o.kt)("h3",{id:"tunehyperparameters"},"TuneHyperparameters"),(0,o.kt)(s.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,o.kt)(l.Z,{value:"py",mdxType:"TabItem"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.automl import *\nfrom synapse.ml.train import *\nfrom pyspark.ml.classification import LogisticRegression, RandomForestClassifier, GBTClassifier\n\n\ndf = (spark.createDataFrame([\n    (0, 1, 1, 1, 1, 1, 1.0, 3, 1, 1),\n    (0, 1, 1, 1, 1, 2, 1.0, 1, 1, 1),\n    (0, 1, 1, 1, 1, 2, 1.0, 2, 1, 1),\n    (0, 1, 2, 3, 1, 2, 1.0, 3, 1, 1),\n    (0, 3, 1, 1, 1, 2, 1.0, 3, 1, 1)\n], ["Label", "Clump_Thickness", "Uniformity_of_Cell_Size",\n    "Uniformity_of_Cell_Shape", "Marginal_Adhesion", "Single_Epithelial_Cell_Size",\n    "Bare_Nuclei", "Bland_Chromatin", "Normal_Nucleoli", "Mitoses"]))\n\nlogReg = LogisticRegression()\nrandForest = RandomForestClassifier()\ngbt = GBTClassifier()\nsmlmodels = [logReg, randForest, gbt]\nmmlmodels = [TrainClassifier(model=model, labelCol="Label") for model in smlmodels]\n\nparamBuilder = (HyperparamBuilder()\n    .addHyperparam(logReg, logReg.regParam, RangeHyperParam(0.1, 0.3))\n    .addHyperparam(randForest, randForest.numTrees, DiscreteHyperParam([5,10]))\n    .addHyperparam(randForest, randForest.maxDepth, DiscreteHyperParam([3,5]))\n    .addHyperparam(gbt, gbt.maxBins, RangeHyperParam(8,16))\n    .addHyperparam(gbt, gbt.maxDepth, DiscreteHyperParam([3,5])))\nsearchSpace = paramBuilder.build()\n# The search space is a list of params to tuples of estimator and hyperparam\nrandomSpace = RandomSpace(searchSpace)\n\nbestModel = TuneHyperparameters(\n              evaluationMetric="accuracy", models=mmlmodels, numFolds=2,\n              numRuns=len(mmlmodels) * 2, parallelism=2,\n              paramSpace=randomSpace.space(), seed=0).fit(df)\n'))),(0,o.kt)(l.Z,{value:"scala",mdxType:"TabItem"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.automl._\nimport com.microsoft.azure.synapse.ml.train._\nimport spark.implicits._\n\nval logReg = new LogisticRegression()\nval randForest = new RandomForestClassifier()\nval gbt = new GBTClassifier()\nval smlmodels = Seq(logReg, randForest, gbt)\nval mmlmodels = smlmodels.map(model => new TrainClassifier().setModel(model).setLabelCol("Label"))\n\nval paramBuilder = new HyperparamBuilder()\n  .addHyperparam(logReg.regParam, new DoubleRangeHyperParam(0.1, 0.3))\n  .addHyperparam(randForest.numTrees, new DiscreteHyperParam(List(5,10)))\n  .addHyperparam(randForest.maxDepth, new DiscreteHyperParam(List(3,5)))\n  .addHyperparam(gbt.maxBins, new IntRangeHyperParam(8,16))\n.addHyperparam(gbt.maxDepth, new DiscreteHyperParam(List(3,5)))\nval searchSpace = paramBuilder.build()\nval randomSpace = new RandomSpace(searchSpace)\n\nval dataset: DataFrame = Seq(\n  (0, 1, 1, 1, 1, 1, 1.0, 3, 1, 1),\n  (0, 1, 1, 1, 1, 2, 1.0, 1, 1, 1),\n  (0, 1, 1, 1, 1, 2, 1.0, 2, 1, 1),\n  (0, 1, 2, 3, 1, 2, 1.0, 3, 1, 1),\n  (0, 3, 1, 1, 1, 2, 1.0, 3, 1, 1))\n  .toDF("Label", "Clump_Thickness", "Uniformity_of_Cell_Size",\n    "Uniformity_of_Cell_Shape", "Marginal_Adhesion", "Single_Epithelial_Cell_Size",\n    "Bare_Nuclei", "Bland_Chromatin", "Normal_Nucleoli", "Mitoses")\n\nval tuneHyperparameters = new TuneHyperparameters().setEvaluationMetric("accuracy")\n  .setModels(mmlmodels.toArray).setNumFolds(2).setNumRuns(mmlmodels.length * 2)\n  .setParallelism(1).setParamSpace(randomSpace).setSeed(0)\ndisplay(tuneHyperparameters.fit(dataset))\n')))),(0,o.kt)(i.Z,{className:"TuneHyperparameters",py:"synapse.ml.automl.html#module-synapse.ml.automl.TuneHyperparameters",scala:"com/microsoft/azure/synapse/ml/automl/TuneHyperparameters.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/automl/TuneHyperparameters.scala",mdxType:"DocTable"}))}y.isMDXComponent=!0},6010:function(e,n,a){"use strict";function t(e){var n,a,r="";if("string"==typeof e||"number"==typeof e)r+=e;else if("object"==typeof e)if(Array.isArray(e))for(n=0;n<e.length;n++)e[n]&&(a=t(e[n]))&&(r&&(r+=" "),r+=a);else for(n in e)e[n]&&(r&&(r+=" "),r+=n);return r}function r(){for(var e,n,a=0,r="";a<arguments.length;)(e=arguments[a++])&&(n=t(e))&&(r&&(r+=" "),r+=n);return r}a.d(n,{Z:function(){return r}})}}]);