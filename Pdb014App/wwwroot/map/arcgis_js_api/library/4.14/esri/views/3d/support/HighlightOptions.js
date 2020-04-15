// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/tsSupport/declareExtendsHelper ../../../core/tsSupport/decorateHelper ../../../Color ../../../core/Accessor ../../../core/maybe ../../../core/accessorSupport/decorators ../../../core/libs/gl-matrix-2/vec4f32".split(" "),function(m,n,h,d,e,k,l,c,g){return function(f){function a(){var b=null!==f&&f.apply(this,arguments)||this;b.color=new e([0,255,255]);b.haloColor=null;b.haloOpacity=1;b.fillOpacity=.25;return b}h(a,f);a.toEngineOptions=function(b){var a=e.toUnitRGBA(b.color),
c=l.isSome(b.haloColor)?e.toUnitRGBA(b.haloColor):a;return{color:g.vec4f32.fromValues(a[0],a[1],a[2],a[3]),haloColor:g.vec4f32.fromValues(c[0],c[1],c[2],c[3]),haloOpacity:b.haloOpacity,haloOpacityOccluded:.25*b.haloOpacity,fillOpacity:b.fillOpacity,fillOpacityOccluded:.25*b.fillOpacity}};d([c.property({type:e})],a.prototype,"color",void 0);d([c.property({type:e})],a.prototype,"haloColor",void 0);d([c.property()],a.prototype,"haloOpacity",void 0);d([c.property()],a.prototype,"fillOpacity",void 0);
return a=d([c.subclass("esri.views.3d.support.HighlightOptions")],a)}(c.declared(k))});