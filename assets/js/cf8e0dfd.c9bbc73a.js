(self.webpackChunksynapseml=self.webpackChunksynapseml||[]).push([[3345,7845],{3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return m},kt:function(){return g}});var r=n(7294);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function s(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?s(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):s(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function i(e,t){if(null==e)return{};var n,r,a=function(e,t){if(null==e)return{};var n,r,a={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var l=r.createContext({}),c=function(e){var t=r.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},m=function(e){var t=c(e.components);return r.createElement(l.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},p=r.forwardRef((function(e,t){var n=e.components,a=e.mdxType,s=e.originalType,l=e.parentName,m=i(e,["components","mdxType","originalType","parentName"]),p=c(n),g=a,f=p["".concat(l,".").concat(g)]||p[g]||u[g]||s;return n?r.createElement(f,o(o({ref:t},m),{},{components:n})):r.createElement(f,o({ref:t},m))}));function g(e,t){var n=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var s=n.length,o=new Array(s);o[0]=p;var i={};for(var l in t)hasOwnProperty.call(t,l)&&(i[l]=t[l]);i.originalType=e,i.mdxType="string"==typeof e?e:a,o[1]=i;for(var c=2;c<s;c++)o[c]=n[c];return r.createElement.apply(null,o)}return r.createElement.apply(null,n)}p.displayName="MDXCreateElement"},1332:function(e,t,n){"use strict";var r=n(7294);t.Z=function(e){var t=e.children,n=e.hidden,a=e.className;return r.createElement("div",{role:"tabpanel",hidden:n,className:a},t)}},5386:function(e,t,n){"use strict";n.d(t,{Z:function(){return u}});var r=n(7294),a=n(8578);var s=function(){var e=(0,r.useContext)(a.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},o=n(6010),i="tabItem_2kG2",l="tabItemActive_3NDg";var c=37,m=39;var u=function(e){var t=e.lazy,n=e.block,a=e.defaultValue,u=e.values,p=e.groupId,g=e.className,f=s(),d=f.tabGroupChoices,b=f.setTabGroupChoices,h=(0,r.useState)(a),y=h[0],v=h[1],L=r.Children.toArray(e.children),k=[];if(null!=p){var M=d[p];null!=M&&M!==y&&u.some((function(e){return e.value===M}))&&v(M)}var C=function(e){var t=e.currentTarget,n=k.indexOf(t),r=u[n].value;v(r),null!=p&&(b(p,r),setTimeout((function(){var e,n,r,a,s,o,i,c;(e=t.getBoundingClientRect(),n=e.top,r=e.left,a=e.bottom,s=e.right,o=window,i=o.innerHeight,c=o.innerWidth,n>=0&&s<=c&&a<=i&&r>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(l),setTimeout((function(){return t.classList.remove(l)}),2e3))}),150))},G=function(e){var t,n;switch(e.keyCode){case m:var r=k.indexOf(e.target)+1;n=k[r]||k[0];break;case c:var a=k.indexOf(e.target)-1;n=k[a]||k[k.length-1]}null==(t=n)||t.focus()};return r.createElement("div",{className:"tabs-container"},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,o.Z)("tabs",{"tabs--block":n},g)},u.map((function(e){var t=e.value,n=e.label;return r.createElement("li",{role:"tab",tabIndex:y===t?0:-1,"aria-selected":y===t,className:(0,o.Z)("tabs__item",i,{"tabs__item--active":y===t}),key:t,ref:function(e){return k.push(e)},onKeyDown:G,onFocus:C,onClick:C},n)}))),t?(0,r.cloneElement)(L.filter((function(e){return e.props.value===y}))[0],{className:"margin-vert--md"}):r.createElement("div",{className:"margin-vert--md"},L.map((function(e,t){return(0,r.cloneElement)(e,{key:t,hidden:e.props.value!==y})}))))}},8578:function(e,t,n){"use strict";var r=(0,n(7294).createContext)(void 0);t.Z=r},1989:function(e,t,n){"use strict";var r=n(7294),a=n(2263);t.Z=function(e){var t=e.className,n=e.py,s=e.scala,o=e.sourceLink,i=(0,a.Z)().siteConfig.customFields.version,l="https://mmlspark.blob.core.windows.net/docs/"+i+"/pyspark/"+n,c="https://mmlspark.blob.core.windows.net/docs/"+i+"/scala/"+s;return r.createElement("table",null,r.createElement("tbody",null,r.createElement("tr",null,r.createElement("td",null,r.createElement("strong",null,"Python API: "),r.createElement("a",{href:l},t)),r.createElement("td",null,r.createElement("strong",null,"Scala API: "),r.createElement("a",{href:c},t)),r.createElement("td",null,r.createElement("strong",null,"Source: "),r.createElement("a",{href:o},t)))))}},6575:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return m},contentTitle:function(){return u},metadata:function(){return p},toc:function(){return g},default:function(){return d}});var r=n(2122),a=n(9756),s=(n(7294),n(3905)),o=n(5386),i=n(1332),l=n(1989),c=["components"],m={},u=void 0,p={unversionedId:"documentation/estimators/_LightGBM",id:"documentation/estimators/_LightGBM",isDocsHomePage:!1,title:"_LightGBM",description:"\x3c!--",source:"@site/docs/documentation/estimators/_LightGBM.md",sourceDirName:"documentation/estimators",slug:"/documentation/estimators/_LightGBM",permalink:"/SynapseML/docs/next/documentation/estimators/_LightGBM",version:"current",frontMatter:{}},g=[{value:"LightGBMClassifier",id:"lightgbmclassifier",children:[]},{value:"LightGBMRanker",id:"lightgbmranker",children:[]},{value:"LightGBMRegressor",id:"lightgbmregressor",children:[]}],f={toc:g};function d(e){var t=e.components,n=(0,a.Z)(e,c);return(0,s.kt)("wrapper",(0,r.Z)({},f,n,{components:t,mdxType:"MDXLayout"}),(0,s.kt)("h2",{id:"lightgbmclassifier"},"LightGBMClassifier"),(0,s.kt)(o.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(i.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.lightgbm import *\n\nlgbmClassifier = (LightGBMClassifier()\n      .setFeaturesCol("features")\n      .setRawPredictionCol("rawPrediction")\n      .setDefaultListenPort(12402)\n      .setNumLeaves(5)\n      .setNumIterations(10)\n      .setObjective("binary")\n      .setLabelCol("labels")\n      .setLeafPredictionCol("leafPrediction")\n      .setFeaturesShapCol("featuresShap"))\n'))),(0,s.kt)(i.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.lightgbm._\n\nval lgbmClassifier = (new LightGBMClassifier()\n      .setFeaturesCol("features")\n      .setRawPredictionCol("rawPrediction")\n      .setDefaultListenPort(12402)\n      .setNumLeaves(5)\n      .setNumIterations(10)\n      .setObjective("binary")\n      .setLabelCol("labels")\n      .setLeafPredictionCol("leafPrediction")\n      .setFeaturesShapCol("featuresShap"))\n')))),(0,s.kt)(l.Z,{className:"LightGBMClassifier",py:"synapse.ml.lightgbm.html#module-synapse.ml.lightgbm.LightGBMClassifier",scala:"com/microsoft/azure/synapse/ml/lightgbm/LightGBMClassifier.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/lightgbm/src/main/scala/com/microsoft/azure/synapse/ml/lightgbm/LightGBMClassifier.scala",mdxType:"DocTable"}),(0,s.kt)("h2",{id:"lightgbmranker"},"LightGBMRanker"),(0,s.kt)(o.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(i.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.lightgbm import *\n\nlgbmRanker = (LightGBMRanker()\n      .setLabelCol("labels")\n      .setFeaturesCol("features")\n      .setGroupCol("query")\n      .setDefaultListenPort(12402)\n      .setRepartitionByGroupingColumn(False)\n      .setNumLeaves(5)\n      .setNumIterations(10))\n'))),(0,s.kt)(i.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.lightgbm._\n\nval lgbmRanker = (new LightGBMRanker()\n      .setLabelCol("labels")\n      .setFeaturesCol("features")\n      .setGroupCol("query")\n      .setDefaultListenPort(12402)\n      .setRepartitionByGroupingColumn(false)\n      .setNumLeaves(5)\n      .setNumIterations(10))\n')))),(0,s.kt)(l.Z,{className:"LightGBMRanker",py:"synapse.ml.lightgbm.html#module-synapse.ml.lightgbm.LightGBMRanker",scala:"com/microsoft/azure/synapse/ml/lightgbm/LightGBMRanker.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/lightgbm/src/main/scala/com/microsoft/azure/synapse/ml/lightgbm/LightGBMRanker.scala",mdxType:"DocTable"}),(0,s.kt)("h2",{id:"lightgbmregressor"},"LightGBMRegressor"),(0,s.kt)(o.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,s.kt)(i.Z,{value:"py",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.lightgbm import *\n\nlgbmRegressor = (LightGBMRegressor()\n      .setLabelCol("labels")\n      .setFeaturesCol("features")\n      .setDefaultListenPort(12402)\n      .setNumLeaves(5)\n      .setNumIterations(10))\n'))),(0,s.kt)(i.Z,{value:"scala",mdxType:"TabItem"},(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.lightgbm._\n\nval lgbmRegressor = (new LightGBMRegressor()\n      .setLabelCol("labels")\n      .setFeaturesCol("features")\n      .setDefaultListenPort(12402)\n      .setNumLeaves(5)\n      .setNumIterations(10))\n')))),(0,s.kt)(l.Z,{className:"LightGBMRegressor",py:"synapse.ml.lightgbm.html#module-synapse.ml.lightgbm.LightGBMRegressor",scala:"com/microsoft/azure/synapse/ml/lightgbm/LightGBMRegressor.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/lightgbm/src/main/scala/com/microsoft/azure/synapse/ml/lightgbm/LightGBMRegressor.scala",mdxType:"DocTable"}))}d.isMDXComponent=!0},849:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return l},contentTitle:function(){return c},metadata:function(){return m},toc:function(){return u},default:function(){return g}});var r=n(2122),a=n(9756),s=(n(7294),n(3905)),o=n(6575),i=["components"],l={title:"Estimators - LightGBM",sidebar_label:"LightGBM",hide_title:!0},c="LightGBM",m={unversionedId:"documentation/estimators/estimators_lightgbm",id:"documentation/estimators/estimators_lightgbm",isDocsHomePage:!1,title:"Estimators - LightGBM",description:"export const toc = [...LightGBMTOC]",source:"@site/docs/documentation/estimators/estimators_lightgbm.md",sourceDirName:"documentation/estimators",slug:"/documentation/estimators/estimators_lightgbm",permalink:"/SynapseML/docs/next/documentation/estimators/estimators_lightgbm",version:"current",frontMatter:{title:"Estimators - LightGBM",sidebar_label:"LightGBM",hide_title:!0},sidebar:"docs",previous:{title:"Core",permalink:"/SynapseML/docs/next/documentation/estimators/estimators_core"},next:{title:"Vowpal Wabbit",permalink:"/SynapseML/docs/next/documentation/estimators/estimators_vw"}},u=[].concat(o.toc),p={toc:u};function g(e){var t=e.components,n=(0,a.Z)(e,i);return(0,s.kt)("wrapper",(0,r.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,s.kt)("h1",{id:"lightgbm"},"LightGBM"),(0,s.kt)(o.default,{mdxType:"LightGBM"}))}g.isMDXComponent=!0},6010:function(e,t,n){"use strict";function r(e){var t,n,a="";if("string"==typeof e||"number"==typeof e)a+=e;else if("object"==typeof e)if(Array.isArray(e))for(t=0;t<e.length;t++)e[t]&&(n=r(e[t]))&&(a&&(a+=" "),a+=n);else for(t in e)e[t]&&(a&&(a+=" "),a+=t);return a}function a(){for(var e,t,n=0,a="";n<arguments.length;)(e=arguments[n++])&&(t=r(e))&&(a&&(a+=" "),a+=t);return a}n.d(t,{Z:function(){return a}})}}]);