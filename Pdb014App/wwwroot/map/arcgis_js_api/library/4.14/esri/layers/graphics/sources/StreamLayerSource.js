// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("../../../core/declare ../../../core/Accessor ../../../core/Promise ../../../core/lang ../../../core/urlUtils ../../../core/promiseUtils ../../../geometry/Extent ../../support/WebSocketConnector ../../../tasks/QueryTask ../../../request".split(" "),function(p,q,r,k,m,l,t,u,n,v){return p([q,r.EsriPromise],{declaredClass:"esri.layers.graphics.sources.StreamLayerSource",constructor:function(a){if(a=a&&a.layer)this.url=a.url},initialize:function(){this.addResolvingPromise(this._fetchLayers())},
properties:{connectionInfo:{get:function(){if(this.layer.hasMemorySource||this.layer.socketUrl)return{serviceSocketUrls:[this.layer.socketUrl]};if(this.sourceJSON){var a={},b=this.sourceJSON,d=[],c=[],g=[],e,f,h;b.streamUrls&&b.streamUrls.forEach(function(b){"ws"===b.transport&&(d=b.urls,a.token=b.token)},this);d.forEach(function(a){0===a.lastIndexOf("wss",0)?g.push(a):c.push(a)});if((b="https"===m.appUrl.scheme||0===this.url.lastIndexOf("https:",0)?g:0===c.length?g:c)&&1<b.length)for(e=0;e<b.length-
1;e++)f=e+Math.floor(Math.random()*(b.length-e)),h=b[f],b[f]=b[e],b[e]=h;a.serviceSocketUrls=b;return a}}},latestUrl:{get:function(){var a=this.sourceJSON;return(a=a.keepLatestArchive&&a.keepLatestArchive.featuresUrl)?a:null}},latestQueryTask:{get:function(){var a=this.latestUrl;return a?new n(a):null}},layer:{},relatedFeaturesInfo:{get:function(){var a=(this.sourceJSON||{}).relatedFeatures;return a=a&&a.featuresUrl?a:null}},relatedFeaturesQueryTask:{get:function(){var a=this.relatedFeaturesInfo;
return(a=a?a.featuresUrl:null)?new n(a):null}},parsedUrl:{get:function(){return this.url?m.urlToObject(this.url):null}},url:null},createWebSocketConnector:function(a){var b=l.createDeferred();this.when(function(){var d=this.connectionInfo,c,g=this.layer.spatialReference,e,f,h={};try{c=this.makeFilter()}catch(w){b.reject(w);return}d?(d.socketUrl?f=[d.socketUrl]:d.serviceSocketUrls&&(f=d.serviceSocketUrls.map(function(a){return a+"/"+this.layer.socketDirection}.bind(this))),h.socketUrls=f,c&&(c.where||
c.geometry||c.outFields)&&((f=c.geometry)&&"string"!==typeof f&&(f=f.toJSON?JSON.stringify(f.toJSON()):JSON.stringify(f)),e=k.mixin(e||{},{where:c.where,geometry:f,outFields:c.outFields})),d.token&&(e=k.mixin(e||{},{token:d.token})),a&&g&&a.wkid!==g.wkid&&(e=k.mixin(e||{},{outSR:a.wkid})),h.queryParams=e,h.layerSource=this,d=new u(h),b.resolve(d)):b.reject(Error("No web socket urls found"))}.bind(this));return b.promise},getWebSocketToken:function(){return this._fetchStreamLayer().then(function(a){a=
a.data;var b=null;a.streamUrls&&a.streamUrls.some(function(a){if("ws"===a.transport)return b=a.token,!0},this);return b}.bind(this))},makeFilter:function(a){var b=this.layer,d=null,c;if(a){if(c={},a.hasOwnProperty("where")&&(c.where=a.where),a.hasOwnProperty("geometry")){if((b=a.geometry)&&!b.hasOwnProperty("xmin"))throw Error("Cannot make filter. Only Extent is supported for the geometry filter");b&&!b.declaredClass&&(b=new t(b));c.geometry=b}}else if(c=b.filter||{},c={where:c.where,geometry:c.geometry},
(a=this.relatedFeaturesInfo&&this.relatedFeaturesInfo.outFields||b.outFields)&&-1===a.indexOf("*")){var g=b.fields.map(function(a){return a.name}),d=a.filter(function(a){return-1!==g.indexOf(a)}).join(",");c=k.mixin(c||{},{outFields:d})}return c},queryFeatures:function(a,b){return l.reject()},_fetchLayers:function(){return this._fetchStreamLayer().then(function(a){a.ssl&&(this.url=this.url.replace(/^http:/i,"https:"));this.sourceJSON=a.data;return this._fetchArchiveLayer()}.bind(this)).then(function(a){this.archivedLayerDefinition=
a&&a.data;return this._fetchRelatedLayer()}.bind(this)).then(function(a){this.relatedLayerDefinition=a&&a.data}.bind(this))},_fetchStreamLayer:function(){return this._requestServiceDefinition({url:this.layer.parsedUrl.path,content:k.mixin({f:"json"},this.layer.parsedUrl.query)})},_fetchArchiveLayer:function(){var a=this.latestUrl;return a?this._requestServiceDefinition({url:a}):l.resolve()},_fetchRelatedLayer:function(){var a=this.relatedFeaturesInfo;return a?this._requestServiceDefinition({url:a.featuresUrl}):
l.resolve()},_requestServiceDefinition:function(a){return a&&a.url?v(a.url,{query:k.mixin(a.content||{},{f:"json"}),responseType:"json"}):l.reject(Error("url is a required options property"))}})});