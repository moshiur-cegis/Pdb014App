// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../core/tsSupport/decorateHelper ../../core/tsSupport/declareExtendsHelper ../../geometry ../../core/Accessor ../../core/jsonMap ../../core/accessorSupport/decorators ../../geometry/support/jsonUtils".split(" "),function(n,p,d,h,e,k,l,c,f){var m=new l.JSONMap({9001:"meters",9002:"feet",9036:"kilometers",9093:"miles",109012:"nautical-miles",109001:"yards"});return function(g){function a(b){b=g.call(this,b)||this;b.geometry1=null;b.geometry2=null;b.distanceUnit=null;b.geodesic=
null;return b}h(a,g);a.prototype.toJSON=function(){var b={},a=this.geometry1;a&&(b.geometry1=JSON.stringify({geometryType:f.getJsonType(a),geometry:a}),b.sr=JSON.stringify(this.geometry1.spatialReference.toJSON()));if(a=this.geometry2)b.geometry2=JSON.stringify({geometryType:f.getJsonType(a),geometry:a});this.distanceUnit&&(b.distanceUnit=m.toJSON(this.distanceUnit));this.geodesic&&(b.geodesic=this.geodesic);return b};d([c.property({types:e.geometryTypes,json:{write:!0}})],a.prototype,"geometry1",
void 0);d([c.property({types:e.geometryTypes,json:{write:!0}})],a.prototype,"geometry2",void 0);d([c.property({type:String,json:{write:!0}})],a.prototype,"distanceUnit",void 0);d([c.property({type:Boolean,json:{write:!0}})],a.prototype,"geodesic",void 0);return a=d([c.subclass("esri.tasks.support.DistanceParameters")],a)}(c.declared(k))});