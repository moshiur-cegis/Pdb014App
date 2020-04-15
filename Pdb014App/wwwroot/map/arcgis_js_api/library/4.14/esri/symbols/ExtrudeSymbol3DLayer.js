// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../core/tsSupport/declareExtendsHelper ../core/tsSupport/decorateHelper ../core/maybe ../core/accessorSupport/decorators ./Symbol3DLayer ./edges/utils ./support/Symbol3DMaterial".split(" "),function(m,n,f,c,g,b,h,k,l){return function(e){function a(a){a=e.call(this,a)||this;a.type="extrude";a.size=void 0;a.material=null;a.castShadows=!0;a.edges=null;return a}f(a,e);d=a;a.prototype.clone=function(){return new d({edges:this.edges&&this.edges.clone(),enabled:this.enabled,material:g.isSome(this.material)?
this.material.clone():null,castShadows:this.castShadows,size:this.size})};var d;c([b.enumeration.serializable()({Extrude:"extrude"})],a.prototype,"type",void 0);c([b.property({type:Number,json:{write:!0}})],a.prototype,"size",void 0);c([b.property({type:l.default,json:{write:!0}})],a.prototype,"material",void 0);c([b.property({type:Boolean,nonNullable:!0,json:{write:!0,default:!0}})],a.prototype,"castShadows",void 0);c([b.property(k.symbol3dEdgesProperty)],a.prototype,"edges",void 0);return a=d=c([b.subclass("esri.symbols.ExtrudeSymbol3DLayer")],
a)}(b.declared(h))});