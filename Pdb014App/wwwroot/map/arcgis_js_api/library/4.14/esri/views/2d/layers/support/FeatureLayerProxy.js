// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/tsSupport/declareExtendsHelper ../../../../core/tsSupport/decorateHelper ../../../../core/tsSupport/assignHelper ../../../../core/tsSupport/generatorHelper ../../../../core/tsSupport/awaiterHelper ../../../../core/Promise ../../../../core/promiseUtils ../../../../core/requireUtils ../../../../core/workers ../../../../core/accessorSupport/decorators module".split(" "),function(n,f,p,k,l,e,c,q,m,r,t,g,u){Object.defineProperty(f,"__esModule",{value:!0});l=function(f){function a(b){b=
f.call(this,b)||this;b._startupResolver=m.createResolver();b.isReady=!1;return b}p(a,f);a.prototype.initialize=function(){this._controller=m.createAbortController();this.addResolvingPromise(this._startWorker(this._controller.signal))};a.prototype.destroy=function(){this._connection.close();this._controller.abort()};Object.defineProperty(a.prototype,"tileRenderer",{set:function(b){this.client.tileRenderer=b},enumerable:!0,configurable:!0});a.prototype.startup=function(b,d,a,v){return c(this,void 0,
void 0,function(){var h,c,f,g;return e(this,function(e){switch(e.label){case 0:return h=this._controller.signal,c=Array.isArray(a.source)?{transferList:a.source,signal:h}:void 0,f=b.tileInfo.toJSON(),g={service:a,config:d,tileInfo:f,options:v},[4,this._connection.invoke("startup",g,c)];case 1:return e.sent(),this._startupResolver.resolve(),this._set("isReady",!0),[2]}})})};a.prototype.update=function(b,d){return c(this,void 0,void 0,function(){var a;return e(this,function(h){switch(h.label){case 0:return a=
{config:b,options:d},[4,this._startupResolver.promise];case 1:return h.sent(),[2,this._connection.invoke("update",a)]}})})};a.prototype.setHighlight=function(b){return c(this,void 0,void 0,function(){return e(this,function(d){switch(d.label){case 0:return[4,this._startupResolver.promise];case 1:return d.sent(),[2,this._connection.invoke("controller.setHighlight",b)]}})})};a.prototype.refresh=function(){return c(this,void 0,void 0,function(){return e(this,function(b){switch(b.label){case 0:return[4,
this._startupResolver.promise];case 1:return b.sent(),[2,this._connection.invoke("controller.refresh")]}})})};a.prototype.setViewState=function(b){return c(this,void 0,void 0,function(){return e(this,function(d){switch(d.label){case 0:return[4,this._startupResolver.promise];case 1:return d.sent(),[2,this._connection.invoke("setViewState",b.toJSON())]}})})};a.prototype.queryFeatures=function(b,d){return c(this,void 0,void 0,function(){return e(this,function(a){switch(a.label){case 0:return[4,this._startupResolver.promise];
case 1:return a.sent(),[2,this._connection.invoke("controller.queryFeatures",b.toJSON(),d)]}})})};a.prototype.queryObjectIds=function(b,d){return c(this,void 0,void 0,function(){return e(this,function(a){switch(a.label){case 0:return[4,this._startupResolver.promise];case 1:return a.sent(),[2,this._connection.invoke("controller.queryObjectIds",b.toJSON(),d)]}})})};a.prototype.queryFeatureCount=function(b,d){return c(this,void 0,void 0,function(){return e(this,function(a){switch(a.label){case 0:return[4,
this._startupResolver.promise];case 1:return a.sent(),[2,this._connection.invoke("controller.queryFeatureCount",b.toJSON(),d)]}})})};a.prototype.queryExtent=function(b,a){return c(this,void 0,void 0,function(){return e(this,function(d){return[2,this._connection.invoke("controller.queryExtent",b.toJSON(),a)]})})};a.prototype.queryLatestObservations=function(b,a){return c(this,void 0,void 0,function(){return e(this,function(d){switch(d.label){case 0:return[4,this._startupResolver.promise];case 1:return d.sent(),
[2,this._connection.invoke("controller.queryLatestObservations",b.toJSON(),a)]}})})};a.prototype.queryStatistics=function(b){return c(this,void 0,void 0,function(){return e(this,function(a){switch(a.label){case 0:return[4,this._startupResolver.promise];case 1:return a.sent(),[2,this._connection.invoke("controller.queryStatistics",b)]}})})};a.prototype.getObjectId=function(a){return c(this,void 0,void 0,function(){return e(this,function(b){switch(b.label){case 0:return[4,this._startupResolver.promise];
case 1:return b.sent(),[2,this._connection.invoke("controller.getObjectId",a)]}})})};a.prototype.getLocalId=function(a){return c(this,void 0,void 0,function(){return e(this,function(b){switch(b.label){case 0:return[4,this._startupResolver.promise];case 1:return b.sent(),[2,this._connection.invoke("controller.getLocalId",a)]}})})};a.prototype.getAggregate=function(a){return c(this,void 0,void 0,function(){return e(this,function(b){switch(b.label){case 0:return[4,this._startupResolver.promise];case 1:return b.sent(),
[2,this._connection.invoke("controller.getAggregate",a)]}})})};a.prototype.getAggregateValueRanges=function(){return c(this,void 0,void 0,function(){return e(this,function(a){switch(a.label){case 0:return[4,this._startupResolver.promise];case 1:return a.sent(),[2,this._connection.invoke("controller.getAggregateValueRanges")]}})})};a.prototype.mapValidLocalIds=function(a){return c(this,void 0,void 0,function(){return e(this,function(b){switch(b.label){case 0:return[4,this._startupResolver.promise];
case 1:return b.sent(),[2,this._connection.invoke("controller.mapValidLocalIds",a)]}})})};a.prototype.onEdits=function(a){return c(this,void 0,void 0,function(){var b,c,f;return e(this,function(d){switch(d.label){case 0:return[4,this._startupResolver.promise];case 1:return d.sent(),b=a.addedFeatures,c=a.deletedFeatures,f=a.updatedFeatures,[2,this._connection.invoke("controller.onEdits",{addedFeatures:b,deletedFeatures:c,updatedFeatures:f})]}})})};a.prototype.enableEvent=function(a,d){return c(this,
void 0,void 0,function(){return e(this,function(b){switch(b.label){case 0:return[4,this._startupResolver.promise];case 1:return b.sent(),[2,this._connection.invoke("controller.enableEvent",{name:a,value:d})]}})})};a.prototype._startWorker=function(a){return c(this,void 0,void 0,function(){var b,c;return e(this,function(d){switch(d.label){case 0:return b=r.getAbsMid("../features/Pipeline",n,u),[4,t.open(b,{client:this.client,strategy:"dedicated",signal:a})];case 1:return this._connection=c=d.sent(),
[2]}})})};k([g.property()],a.prototype,"isReady",void 0);k([g.property()],a.prototype,"client",void 0);k([g.property()],a.prototype,"tileRenderer",null);return a=k([g.subclass("esri.views.2d.layers.support.FeatureLayerProxy")],a)}(g.declared(q.EsriPromise));f.default=l});