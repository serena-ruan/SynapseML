(self.webpackChunksynapseml=self.webpackChunksynapseml||[]).push([[1842],{3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return u},kt:function(){return p}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function a(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function s(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?a(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):a(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function i(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},a=Object.keys(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var l=r.createContext({}),c=function(e){var t=r.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):s(s({},t),e)),n},u=function(e){var t=c(e.components);return r.createElement(l.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},f=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,a=e.originalType,l=e.parentName,u=i(e,["components","mdxType","originalType","parentName"]),f=c(n),p=o,d=f["".concat(l,".").concat(p)]||f[p]||m[p]||a;return n?r.createElement(d,s(s({ref:t},u),{},{components:n})):r.createElement(d,s({ref:t},u))}));function p(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var a=n.length,s=new Array(a);s[0]=f;var i={};for(var l in t)hasOwnProperty.call(t,l)&&(i[l]=t[l]);i.originalType=e,i.mdxType="string"==typeof e?e:o,s[1]=i;for(var c=2;c<a;c++)s[c]=n[c];return r.createElement.apply(null,s)}return r.createElement.apply(null,n)}f.displayName="MDXCreateElement"},1332:function(e,t,n){"use strict";var r=n(7294);t.Z=function(e){var t=e.children,n=e.hidden,o=e.className;return r.createElement("div",{role:"tabpanel",hidden:n,className:o},t)}},5386:function(e,t,n){"use strict";n.d(t,{Z:function(){return m}});var r=n(7294),o=n(8578);var a=function(){var e=(0,r.useContext)(o.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},s=n(6010),i="tabItem_2kG2",l="tabItemActive_3NDg";var c=37,u=39;var m=function(e){var t=e.lazy,n=e.block,o=e.defaultValue,m=e.values,f=e.groupId,p=e.className,d=a(),v=d.tabGroupChoices,y=d.setTabGroupChoices,b=(0,r.useState)(o),h=b[0],g=b[1],k=r.Children.toArray(e.children),E=[];if(null!=f){var O=v[f];null!=O&&O!==h&&m.some((function(e){return e.value===O}))&&g(O)}var w=function(e){var t=e.currentTarget,n=E.indexOf(t),r=m[n].value;g(r),null!=f&&(y(f,r),setTimeout((function(){var e,n,r,o,a,s,i,c;(e=t.getBoundingClientRect(),n=e.top,r=e.left,o=e.bottom,a=e.right,s=window,i=s.innerHeight,c=s.innerWidth,n>=0&&a<=c&&o<=i&&r>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(l),setTimeout((function(){return t.classList.remove(l)}),2e3))}),150))},C=function(e){var t,n;switch(e.keyCode){case u:var r=E.indexOf(e.target)+1;n=E[r]||E[0];break;case c:var o=E.indexOf(e.target)-1;n=E[o]||E[E.length-1]}null==(t=n)||t.focus()};return r.createElement("div",{className:"tabs-container"},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,s.Z)("tabs",{"tabs--block":n},p)},m.map((function(e){var t=e.value,n=e.label;return r.createElement("li",{role:"tab",tabIndex:h===t?0:-1,"aria-selected":h===t,className:(0,s.Z)("tabs__item",i,{"tabs__item--active":h===t}),key:t,ref:function(e){return E.push(e)},onKeyDown:C,onFocus:w,onClick:w},n)}))),t?(0,r.cloneElement)(k.filter((function(e){return e.props.value===h}))[0],{className:"margin-vert--md"}):r.createElement("div",{className:"margin-vert--md"},k.map((function(e,t){return(0,r.cloneElement)(e,{key:t,hidden:e.props.value!==h})}))))}},8578:function(e,t,n){"use strict";var r=(0,n(7294).createContext)(void 0);t.Z=r},1989:function(e,t,n){"use strict";var r=n(7294),o=n(2263);t.Z=function(e){var t=e.className,n=e.py,a=e.scala,s=e.sourceLink,i=(0,o.Z)().siteConfig.customFields.version,l="https://mmlspark.blob.core.windows.net/docs/"+i+"/pyspark/"+n,c="https://mmlspark.blob.core.windows.net/docs/"+i+"/scala/"+a;return r.createElement("table",null,r.createElement("tbody",null,r.createElement("tr",null,r.createElement("td",null,r.createElement("strong",null,"Python API: "),r.createElement("a",{href:l},t)),r.createElement("td",null,r.createElement("strong",null,"Scala API: "),r.createElement("a",{href:c},t)),r.createElement("td",null,r.createElement("strong",null,"Source: "),r.createElement("a",{href:s},t)))))}},2569:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return u},contentTitle:function(){return m},metadata:function(){return f},toc:function(){return p},default:function(){return v}});var r=n(2122),o=n(9756),a=(n(7294),n(3905)),s=n(5386),i=n(1332),l=n(1989),c=["components"],u={},m=void 0,f={unversionedId:"documentation/estimators/core/_IsolationForest",id:"version-0.9.1/documentation/estimators/core/_IsolationForest",isDocsHomePage:!1,title:"_IsolationForest",description:"\x3c!--",source:"@site/versioned_docs/version-0.9.1/documentation/estimators/core/_IsolationForest.md",sourceDirName:"documentation/estimators/core",slug:"/documentation/estimators/core/_IsolationForest",permalink:"/SynapseML/docs/documentation/estimators/core/_IsolationForest",version:"0.9.1",frontMatter:{}},p=[{value:"Isolation Forest",id:"isolation-forest",children:[{value:"IsolationForest",id:"isolationforest",children:[]}]}],d={toc:p};function v(e){var t=e.components,n=(0,o.Z)(e,c);return(0,a.kt)("wrapper",(0,r.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h2",{id:"isolation-forest"},"Isolation Forest"),(0,a.kt)("h3",{id:"isolationforest"},"IsolationForest"),(0,a.kt)(s.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,a.kt)(i.Z,{value:"py",mdxType:"TabItem"},(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.isolationforest import *\n\nisolationForest = (IsolationForest()\n      .setNumEstimators(100)\n      .setBootstrap(False)\n      .setMaxSamples(256)\n      .setMaxFeatures(1.0)\n      .setFeaturesCol("features")\n      .setPredictionCol("predictedLabel")\n      .setScoreCol("outlierScore")\n      .setContamination(0.02)\n      .setContaminationError(0.02 * 0.01)\n      .setRandomSeed(1))\n'))),(0,a.kt)(i.Z,{value:"scala",mdxType:"TabItem"},(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.isolationforest._\nimport spark.implicits._\n\nval isolationForest = (new IsolationForest()\n      .setNumEstimators(100)\n      .setBootstrap(false)\n      .setMaxSamples(256)\n      .setMaxFeatures(1.0)\n      .setFeaturesCol("features")\n      .setPredictionCol("predictedLabel")\n      .setScoreCol("outlierScore")\n      .setContamination(0.02)\n      .setContaminationError(0.02 * 0.01)\n      .setRandomSeed(1))\n')))),(0,a.kt)(l.Z,{className:"CleanMissingData",py:"mmlspark.isolationforest.html#module-mmlspark.isolationforest.IsolationForest",scala:"com/microsoft/azure/synapse/ml/isolationforest/IsolationForest.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/core/src/main/scala/com/microsoft/azure/synapse/ml/isolationforest/IsolationForest.scala",mdxType:"DocTable"}))}v.isMDXComponent=!0},6010:function(e,t,n){"use strict";function r(e){var t,n,o="";if("string"==typeof e||"number"==typeof e)o+=e;else if("object"==typeof e)if(Array.isArray(e))for(t=0;t<e.length;t++)e[t]&&(n=r(e[t]))&&(o&&(o+=" "),o+=n);else for(t in e)e[t]&&(o&&(o+=" "),o+=t);return o}function o(){for(var e,t,n=0,o="";n<arguments.length;)(e=arguments[n++])&&(t=r(e))&&(o&&(o+=" "),o+=t);return o}n.d(t,{Z:function(){return o}})}}]);