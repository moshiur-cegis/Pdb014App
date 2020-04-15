// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../core/tsSupport/extendsHelper ../core/tsSupport/assignHelper ../request ./featureSetCollection ./featureset/sources/FeatureLayerDynamic ./featureset/sources/FeatureLayerMemory ./featureset/sources/FeatureLayerRelated ./featureset/support/cache ./featureset/support/shared ../core/promiseUtils ../layers/FeatureLayer ../portal/Portal ../portal/PortalItem ./featureset/actions/OrderBy ./featureset/actions/Top ./featureset/actions/SpatialFilter ./featureset/actions/AttributeFilter ./featureset/actions/GroupBy".split(" "),
function(N,q,y,z,v,A,D,E,F,e,B,n,r,G,H){function w(c,b){if(e.applicationCache){var d=e.applicationCache.getLayerInfo(c);if(d)return d.then(function(a){return n.resolve(new r({url:c,outFields:b,sourceJSON:a}))});var f=new r({url:c,outFields:b}),d=n.create(function(a,d){f.load().then(function(){a(f.sourceJSON)},function(a){d(a)})});e.applicationCache&&(e.applicationCache.setLayerInfo(c,d),d=d.catch(function(a){e.applicationCache.clearLayerInfo(c);throw a;}));return d.then(function(a){return n.resolve(f)})}return n.resolve(new r({url:c,
outFields:b}))}function x(c,b,d,f,a){return w(c,["*"]).then(function(c){return n.resolve(u(c,b,d,f,a))})}function u(c,b,d,f,a){void 0===b&&(b=null);void 0===d&&(d=null);void 0===f&&(f=!0);void 0===a&&(a=null);return!0===c._hasMemorySource()?new E({layer:c,spatialReference:b,outFields:d,includeGeometry:f,lrucache:a}):new D({layer:c,spatialReference:b,outFields:d,includeGeometry:f,lrucache:a})}function I(c){if(null!==e.applicationCache){var b=e.applicationCache.getLayerInfo(c);if(null!==b)return b}b=
v(c,{responseType:"json",query:{f:"json"}}).then(function(d){return d.data?n.resolve(d.data):n.resolve(null)});null!==e.applicationCache&&(e.applicationCache.setLayerInfo(c,b),b=b.catch(function(d){e.applicationCache.clearLayerInfo(c);throw d;}));return b}function J(c,b){var d="QUERYDATAELEMTS:"+b.toString()+":"+c;if(null!==e.applicationCache){var f=e.applicationCache.getLayerInfo(d);if(null!==f)return f}c=v(c+"/queryDataElements",{method:"post",responseType:"json",query:{layers:JSON.stringify([b.toString()]),
f:"json"}}).then(function(a){if(a.data&&(a=a.data,a.layerDataElements&&a.layerDataElements[0]))return a.layerDataElements[0];throw Error("Not Found");});null!==e.applicationCache&&(e.applicationCache.setLayerInfo(d,c),c=c.catch(function(a){e.applicationCache.clearLayerInfo(d);throw a;}));return c}function C(c){if(null!==e.applicationCache){var b=e.applicationCache.getLayerInfo(c);if(null!==b)return b}b=v(c,{responseType:"json",query:{f:"json"}}).then(function(d){return d.data?(d=d.data,d.layers||
(d.layers=[]),d.tables||(d.tables=[]),n.resolve(d)):n.resolve({layers:[],tables:[]})});null!==e.applicationCache&&(e.applicationCache.setLayerInfo(c,b),b=b.catch(function(d){e.applicationCache.clearLayerInfo(c);throw d;}));return b}Object.defineProperty(q,"__esModule",{value:!0});q.initialiseMetaDataCache=function(){null===e.applicationCache&&(e.applicationCache=new e)};q.constructFeatureSetFromUrl=x;q.constructFeatureSet=u;q.constructAssociationMetaDataFeatureSetFromUrl=function(c,b){var d=[],f=
null,a={},p=null;return C(c).then(function(h){if(h.controllerDatasetLayers&&void 0!==h.controllerDatasetLayers.utilityNetworkLayerId&&null!==h.controllerDatasetLayers.utilityNetworkLayerId){if(h.layers)for(var k=0,e=h.layers;k<e.length;k++){var g=e[k];a[g.id]=g.name}if(h.tables)for(k=0,e=h.tables;k<e.length;k++)g=e[k],a[g.id]=g.name;var t=h.controllerDatasetLayers.utilityNetworkLayerId;return J(c,t).then(function(g){if(g){f=g;p={};f.dataElement.domainNetworks||(f.dataElement.domainNetworks=[]);g=
0;for(var k=f.dataElement.domainNetworks;g<k.length;g++){for(var e=k[g],h=0,l=e.edgeSources?e.edgeSources:[];h<l.length;h++){var m=l[h],m={layerId:m.layerId,sourceId:m.sourceId,className:a[m.layerId]?a[m.layerId]:null};m.className&&(p[m.className]=m)}h=0;for(e=e.junctionSources?e.junctionSources:[];h<e.length;h++)m=e[h],m={layerId:m.layerId,sourceId:m.sourceId,className:a[m.layerId]?a[m.layerId]:null},m.className&&(p[m.className]=m)}if(f.dataElement.terminalConfigurations)for(g=0,k=f.dataElement.terminalConfigurations;g<
k.length;g++)for(e=0,m=k[g].terminals;e<m.length;e++)h=m[e],d.push({terminalId:h.terminalId,terminalName:h.terminalName});return I(c+"/"+t).then(function(a){return a.systemLayers&&void 0!==a.systemLayers.associationsTableId&&null!==a.systemLayers.associationsTableId?x(c+"/"+a.systemLayers.associationsTableId.toString(),b,"OBJECTID FROMNETWORKSOURCEID TONETWORKSOURCEID FROMGLOBALID TOGLOBALID TOTERMINALID FROMTERMINALID ASSOCIATIONTYPE ISCONTENTVISIBLE GLOBALID".split(" "),!1,null).then(function(a){return a.load()}).then(function(a){return{lkp:p,
associations:a,terminals:d}}):{associations:null,lkp:null,terminals:[]}})}return{associations:null,lkp:null,terminals:[]}})}return{associations:null,lkp:null,terminals:[]}})};q.constructFeatureSetFromRelationship=function(c,b,d,f,a,p,e){void 0===f&&(f=null);void 0===a&&(a=null);void 0===p&&(p=!0);void 0===e&&(e=null);var k=c.serviceUrl();if(!k)return null;k="/"===k.charAt(k.length-1)?k+b.relatedTableId.toString():k+"/"+b.relatedTableId.toString();return x(k,f,a,p,e).then(function(k){return new F({layer:c,
relatedLayer:k,relationship:b,objectId:d,spatialReference:f,outFields:a,includeGeometry:p,lrucache:e})})};var L=function(c){function b(d,f,a){void 0===f&&(f=null);void 0===a&&(a=null);var b=c.call(this)||this;b._map=d;b._overridespref=f;b.lrucache=a;b._instantLayers=[];return b}y(b,c);b.prototype.makeAndAddFeatureSet=function(d,f,a){void 0===f&&(f=!0);void 0===a&&(a=null);var b=u(d,this._overridespref,null===a?["*"]:a,f,this.lrucache);this._instantLayers.push({featureset:b,opitem:d,includeGeometry:f,
outFields:JSON.stringify(a)});return b};b.prototype.featureSetByName=function(d,f,a){var b=this;void 0===f&&(f=!0);void 0===a&&(a=null);if(void 0!==this._map.loaded&&void 0!==this._map.load&&!1===this._map.loaded)return this._map.load().then(function(){try{return b.featureSetByName(d,f,a)}catch(t){return n.reject(t)}});null===a&&(a=["*"]);a=a.slice(0);a=a.sort();for(var c=JSON.stringify(a),e=0;e<this._instantLayers.length;e++){var l=this._instantLayers[e];if(l.opitem.title===d&&l.includeGeometry===
f&&l.outFields===c)return this.resolvePromise(this._instantLayers[e].featureset)}if(c=this._map.layers.find(function(a){return a instanceof r&&a.title===d?!0:!1}))return this.resolvePromise(this.makeAndAddFeatureSet(c,f,a));if(this._map.tables){var g=this._map.tables.find(function(a){return a.title&&a.title===d||a.title&&a.title===d?!0:!1});if(g)return g._materializedTable||(c=g.outFields?g:z({},g,{outFields:["*"]}),g._materializedTable=new r(c)),g._materializedTable.load().then(function(){return b.resolvePromise(b.makeAndAddFeatureSet(g._materializedTable,
f,a))})}return this.resolvePromise(null)};b.prototype.featureSetById=function(d,b,a){var f=this;void 0===b&&(b=!0);void 0===a&&(a=["*"]);if(void 0!==this._map.loaded&&void 0!==this._map.load&&!1===this._map.loaded)return this._map.load().then(function(){try{return f.featureSetById(d,b,a)}catch(t){return n.reject(t)}});null===a&&(a=["*"]);a=a.slice(0);a=a.sort();for(var c=JSON.stringify(a),e=0;e<this._instantLayers.length;e++){var l=this._instantLayers[e];if(l.opitem.id===d&&l.includeGeometry===b&&
l.outFields===c)return this.resolvePromise(this._instantLayers[e].featureset)}if(c=this._map.layers.find(function(a){return a instanceof r&&a.id===d?!0:!1}))return this.resolvePromise(this.makeAndAddFeatureSet(c,b,a));if(this._map.tables){var g=this._map.tables.find(function(a){return a.id===d?!0:!1});if(g)return g._materializedTable||(c=z({},g,{outFields:["*"]}),g._materializedTable=new r(c)),g._materializedTable.load().then(function(){return f.resolvePromise(f.makeAndAddFeatureSet(g._materializedTable,
b,a))})}return this.resolvePromise(null)};return b}(A),M=function(c){function b(d,b,a){void 0===b&&(b=null);void 0===a&&(a=null);var f=c.call(this)||this;f._url=d;f._overridespref=b;f.lrucache=a;f.metadata=null;f._instantLayers=[];return f}y(b,c);Object.defineProperty(b.prototype,"url",{get:function(){return this._url},enumerable:!0,configurable:!0});b.prototype.makeAndAddFeatureSet=function(d,b,a){void 0===b&&(b=!0);void 0===a&&(a=null);var c=u(d,this._overridespref,null===a?["*"]:a,b,this.lrucache);
this._instantLayers.push({featureset:c,opitem:d,includeGeometry:b,outFields:JSON.stringify(a)});return c};b.prototype._loadMetaData=function(){var b=this;return C(this._url).then(function(d){return b.metadata=d})};b.prototype.load=function(){return this._loadMetaData()};b.prototype.clone=function(){return new b(this._url,this._overridespref,this.lrucache)};b.prototype.featureSetByName=function(b,c,a){var d=this;void 0===c&&(c=!0);void 0===a&&(a=null);null===a&&(a=["*"]);a=a.slice(0);a=a.sort();for(var e=
JSON.stringify(a),f=0;f<this._instantLayers.length;f++){var l=this._instantLayers[f];if(l.opitem.title===b&&l.includeGeometry===c&&l.outFields===e)return this.resolvePromise(this._instantLayers[f].featureset)}return this._loadMetaData().then(function(f){for(var e=null,g=0,k=f.layers?f.layers:[];g<k.length;g++){var h=k[g];h.name===b&&(e=h)}if(!e)for(g=0,f=f.tables?f.tables:[];g<f.length;g++)h=f[g],h.name===b&&(e=h);return e?w(d._url+"/"+e.id,["*"]).then(function(b){return d.makeAndAddFeatureSet(b,
c,a)}):d.resolvePromise(null)})};b.prototype.featureSetById=function(b,c,a){var d=this;void 0===c&&(c=!0);void 0===a&&(a=["*"]);null===a&&(a=["*"]);a=a.slice(0);a=a.sort();var e=JSON.stringify(a);b=null!==b&&void 0!==b?b.toString():"";for(var f=0;f<this._instantLayers.length;f++){var l=this._instantLayers[f];if(l.opitem.id===b&&l.includeGeometry===c&&l.outFields===e)return this.resolvePromise(this._instantLayers[f].featureset)}return this._loadMetaData().then(function(f){for(var e=null,g=0,k=f.layers?
f.layers:[];g<k.length;g++){var h=k[g];null!==h.id&&void 0!==h.id&&h.id.toString()===b&&(e=h)}if(!e)for(g=0,f=f.tables?f.tables:[];g<f.length;g++)h=f[g],null!==h.id&&void 0!==h.id&&h.id.toString()===b&&(e=h);return e?w(d._url+"/"+e.id,["*"]).then(function(b){return d.makeAndAddFeatureSet(b,c,a)}):d.resolvePromise(null)})};return b}(A);q.createFeatureSetCollectionFromMap=function(c,b,d){void 0===d&&(d=null);return new L(c,b,d)};q.createFeatureSetCollectionFromService=function(c,b,d){void 0===d&&(d=
null);return new M(c,b,d)};q.getPortal=function(c,b){return null===c?b:new G({url:c.field("url")})};q.constructFeatureSetFromPortalItem=function(c,b,d,f,a,p,h){if(e.applicationCache){var k=e.applicationCache.getLayerInfo(c+":"+p.url);if(k)return k.then(function(c){try{var e=new r({url:B.extractServiceUrl(c.url)+"/"+b,outFields:["*"]});return n.resolve(u(e,d,f,a,h))}catch(t){return n.reject(t)}},function(a){return n.reject(a)})}return n.create(function(k,g){var l=(new H({id:c,portal:p})).load();e.applicationCache&&
e.applicationCache.setLayerInfo(c+":"+p.url,l);l.then(function(c){try{var e=new r({url:B.extractServiceUrl(c.url)+"/"+b,outFields:["*"]});k(u(e,d,f,a,h))}catch(K){g(K)}},function(a){e.applicationCache&&e.applicationCache.clearLayerInfo(c+":"+p.url);g(a)})})}});