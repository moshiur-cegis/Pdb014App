// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/tsSupport/declareExtendsHelper ../../../core/tsSupport/decorateHelper ../../../core/accessorSupport/decorators ./PointSizeAlgorithm".split(" "),function(b,c,f,e,d,g){Object.defineProperty(c,"__esModule",{value:!0});b=function(b){function a(){var a=null!==b&&b.apply(this,arguments)||this;a.type="fixed-size";a.size=0;a.useRealWorldSymbolSizes=null;return a}f(a,b);c=a;a.prototype.clone=function(){return new c({size:this.size,useRealWorldSymbolSizes:this.useRealWorldSymbolSizes})};
var c;e([d.enumeration.serializable()({pointCloudFixedSizeAlgorithm:"fixed-size"})],a.prototype,"type",void 0);e([d.property({type:Number,nonNullable:!0,json:{write:!0}})],a.prototype,"size",void 0);e([d.property({type:Boolean,json:{write:!0}})],a.prototype,"useRealWorldSymbolSizes",void 0);return a=c=e([d.subclass("esri.renderers.support.pointCloud.PointSizeFixedSizeAlgorithm")],a)}(d.declared(g.default));c.PointSizeFixedSizeAlgorithm=b;c.default=b});