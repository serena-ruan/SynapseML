(self.webpackChunksynapseml=self.webpackChunksynapseml||[]).push([[9024],{3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return u},kt:function(){return g}});var r=n(7294);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,r,a=function(e,t){if(null==e)return{};var n,r,a={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var c=r.createContext({}),l=function(e){var t=r.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},u=function(e){var t=l(e.components);return r.createElement(c.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},f=r.forwardRef((function(e,t){var n=e.components,a=e.mdxType,i=e.originalType,c=e.parentName,u=s(e,["components","mdxType","originalType","parentName"]),f=l(n),g=a,p=f["".concat(c,".").concat(g)]||f[g]||m[g]||i;return n?r.createElement(p,o(o({ref:t},u),{},{components:n})):r.createElement(p,o({ref:t},u))}));function g(e,t){var n=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var i=n.length,o=new Array(i);o[0]=f;var s={};for(var c in t)hasOwnProperty.call(t,c)&&(s[c]=t[c]);s.originalType=e,s.mdxType="string"==typeof e?e:a,o[1]=s;for(var l=2;l<i;l++)o[l]=n[l];return r.createElement.apply(null,o)}return r.createElement.apply(null,n)}f.displayName="MDXCreateElement"},1332:function(e,t,n){"use strict";var r=n(7294);t.Z=function(e){var t=e.children,n=e.hidden,a=e.className;return r.createElement("div",{role:"tabpanel",hidden:n,className:a},t)}},5386:function(e,t,n){"use strict";n.d(t,{Z:function(){return m}});var r=n(7294),a=n(8578);var i=function(){var e=(0,r.useContext)(a.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},o=n(6010),s="tabItem_2kG2",c="tabItemActive_3NDg";var l=37,u=39;var m=function(e){var t=e.lazy,n=e.block,a=e.defaultValue,m=e.values,f=e.groupId,g=e.className,p=i(),h=p.tabGroupChoices,d=p.setTabGroupChoices,y=(0,r.useState)(a),v=y[0],b=y[1],S=r.Children.toArray(e.children),w=[];if(null!=f){var k=h[f];null!=k&&k!==v&&m.some((function(e){return e.value===k}))&&b(k)}var E=function(e){var t=e.currentTarget,n=w.indexOf(t),r=m[n].value;b(r),null!=f&&(d(f,r),setTimeout((function(){var e,n,r,a,i,o,s,l;(e=t.getBoundingClientRect(),n=e.top,r=e.left,a=e.bottom,i=e.right,o=window,s=o.innerHeight,l=o.innerWidth,n>=0&&i<=l&&a<=s&&r>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(c),setTimeout((function(){return t.classList.remove(c)}),2e3))}),150))},I=function(e){var t,n;switch(e.keyCode){case u:var r=w.indexOf(e.target)+1;n=w[r]||w[0];break;case l:var a=w.indexOf(e.target)-1;n=w[a]||w[w.length-1]}null==(t=n)||t.focus()};return r.createElement("div",{className:"tabs-container"},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,o.Z)("tabs",{"tabs--block":n},g)},m.map((function(e){var t=e.value,n=e.label;return r.createElement("li",{role:"tab",tabIndex:v===t?0:-1,"aria-selected":v===t,className:(0,o.Z)("tabs__item",s,{"tabs__item--active":v===t}),key:t,ref:function(e){return w.push(e)},onKeyDown:I,onFocus:E,onClick:E},n)}))),t?(0,r.cloneElement)(S.filter((function(e){return e.props.value===v}))[0],{className:"margin-vert--md"}):r.createElement("div",{className:"margin-vert--md"},S.map((function(e,t){return(0,r.cloneElement)(e,{key:t,hidden:e.props.value!==v})}))))}},8578:function(e,t,n){"use strict";var r=(0,n(7294).createContext)(void 0);t.Z=r},1989:function(e,t,n){"use strict";var r=n(7294),a=n(2263);t.Z=function(e){var t=e.className,n=e.py,i=e.scala,o=e.sourceLink,s=(0,a.Z)().siteConfig.customFields.version,c="https://mmlspark.blob.core.windows.net/docs/"+s+"/pyspark/"+n,l="https://mmlspark.blob.core.windows.net/docs/"+s+"/scala/"+i;return r.createElement("table",null,r.createElement("tbody",null,r.createElement("tr",null,r.createElement("td",null,r.createElement("strong",null,"Python API: "),r.createElement("a",{href:c},t)),r.createElement("td",null,r.createElement("strong",null,"Scala API: "),r.createElement("a",{href:l},t)),r.createElement("td",null,r.createElement("strong",null,"Source: "),r.createElement("a",{href:o},t)))))}},1983:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return u},contentTitle:function(){return m},metadata:function(){return f},toc:function(){return g},default:function(){return h}});var r=n(2122),a=n(9756),i=(n(7294),n(3905)),o=n(5386),s=n(1332),c=n(1989),l=["components"],u={},m=void 0,f={unversionedId:"documentation/transformers/cognitive/_BingImageSearch",id:"documentation/transformers/cognitive/_BingImageSearch",isDocsHomePage:!1,title:"_BingImageSearch",description:"\x3c!--",source:"@site/docs/documentation/transformers/cognitive/_BingImageSearch.md",sourceDirName:"documentation/transformers/cognitive",slug:"/documentation/transformers/cognitive/_BingImageSearch",permalink:"/SynapseML/docs/next/documentation/transformers/cognitive/_BingImageSearch",version:"current",frontMatter:{}},g=[{value:"Bing Image Search",id:"bing-image-search",children:[{value:"BingImageSearch",id:"bingimagesearch",children:[]}]}],p={toc:g};function h(e){var t=e.components,n=(0,a.Z)(e,l);return(0,i.kt)("wrapper",(0,r.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h2",{id:"bing-image-search"},"Bing Image Search"),(0,i.kt)("h3",{id:"bingimagesearch"},"BingImageSearch"),(0,i.kt)(o.Z,{defaultValue:"py",values:[{label:"Python",value:"py"},{label:"Scala",value:"scala"}],mdxType:"Tabs"},(0,i.kt)(s.Z,{value:"py",mdxType:"TabItem"},(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-python"},'from synapse.ml.cognitive import *\n\nbingSearchKey = os.environ.get("BING_SEARCH_KEY", getSecret("bing-search-key"))\n\n# Number of images Bing will return per query\nimgsPerBatch = 10\n# A list of offsets, used to page into the search results\noffsets = [(i*imgsPerBatch,) for i in range(100)]\n# Since web content is our data, we create a dataframe with options on that data: offsets\nbingParameters = spark.createDataFrame(offsets, ["offset"])\n\n# Run the Bing Image Search service with our text query\nbingSearch = (BingImageSearch()\n              .setSubscriptionKey(bingSearchKey)\n              .setOffsetCol("offset")\n              .setQuery("Martin Luther King Jr. quotes")\n              .setCount(imgsPerBatch)\n              .setOutputCol("images"))\n\n# Transformer that extracts and flattens the richly structured output of Bing Image Search into a simple URL column\ngetUrls = BingImageSearch.getUrlTransformer("images", "url")\n\n# This displays the full results returned\ndisplay(bingSearch.transform(bingParameters))\n\n# Since we have two services, they are put into a pipeline\npipeline = PipelineModel(stages=[bingSearch, getUrls])\n\n# Show the results of your search: image URLs\ndisplay(pipeline.transform(bingParameters))\n\n'))),(0,i.kt)(s.Z,{value:"scala",mdxType:"TabItem"},(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-scala"},'import com.microsoft.azure.synapse.ml.cognitive._\nimport spark.implicits._\n\nval bingSearchKey = sys.env.getOrElse("BING_SEARCH_KEY", None)\n\n// Number of images Bing will return per query\nval imgsPerBatch = 10\n// A list of offsets, used to page into the search results\nval offsets = (0 until 100).map(i => i*imgsPerBatch)\n// Since web content is our data, we create a dataframe with options on that data: offsets\nval bingParameters = Seq(offsets).toDF("offset")\n\n// Run the Bing Image Search service with our text query\nval bingSearch = (new BingImageSearch()\n              .setSubscriptionKey(bingSearchKey)\n              .setOffsetCol("offset")\n              .setQuery("Martin Luther King Jr. quotes")\n              .setCount(imgsPerBatch)\n              .setOutputCol("images"))\n\n// Transformer that extracts and flattens the richly structured output of Bing Image Search into a simple URL column\nval getUrls = BingImageSearch.getUrlTransformer("images", "url")\n\n// This displays the full results returned\ndisplay(bingSearch.transform(bingParameters))\n\n// Show the results of your search: image URLs\ndisplay(getUrls.transform(bingSearch.transform(bingParameters)))\n')))),(0,i.kt)(c.Z,{className:"BingImageSearch",py:"synapse.ml.cognitive.html#module-synapse.ml.cognitive.BingImageSearch",scala:"com/microsoft/azure/synapse/ml/cognitive/BingImageSearch.html",sourceLink:"https://github.com/microsoft/SynapseML/blob/master/cognitive/src/main/scala/com/microsoft/azure/synapse/ml/cognitive/BingImageSearch.scala",mdxType:"DocTable"}))}h.isMDXComponent=!0},6010:function(e,t,n){"use strict";function r(e){var t,n,a="";if("string"==typeof e||"number"==typeof e)a+=e;else if("object"==typeof e)if(Array.isArray(e))for(t=0;t<e.length;t++)e[t]&&(n=r(e[t]))&&(a&&(a+=" "),a+=n);else for(t in e)e[t]&&(a&&(a+=" "),a+=t);return a}function a(){for(var e,t,n=0,a="";n<arguments.length;)(e=arguments[n++])&&(t=r(e))&&(a&&(a+=" "),a+=t);return a}n.d(t,{Z:function(){return a}})}}]);