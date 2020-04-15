// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/tsSupport/declareExtendsHelper ../../../../core/tsSupport/decorateHelper ../../../../geometry ../../../../Viewpoint ../../../../core/Accessor ../../../../core/accessorSupport/decorators ../../../../core/libs/gl-matrix-2/vec2 ../../../../core/libs/gl-matrix-2/vec2f64 ../../viewpointUtils".split(" "),function(r,t,m,d,n,p,q,c,e,f,g){var h=f.vec2f64.create(),k=f.vec2f64.create();return function(l){function a(b){b=l.call(this,b)||this;b._previousCenter=f.vec2f64.create();
b.viewpoint=new p({targetGeometry:new n.Point,scale:0,rotation:0});return b}m(a,l);a.prototype.begin=function(b,a){this.navigation.begin();e.vec2.set(this._previousCenter,a.center.x,a.center.y)};a.prototype.update=function(a,c){var b=a.state,d=b.size,b=b.padding;e.vec2.set(h,c.center.x,c.center.y);g.getAnchor(k,d,b);a.viewpoint=g.rotateBy(this.viewpoint,a.content.viewpoint,g.angleBetween(k,this._previousCenter,h));e.vec2.copy(this._previousCenter,h)};a.prototype.end=function(){this.navigation.end()};
d([c.property()],a.prototype,"viewpoint",void 0);d([c.property()],a.prototype,"navigation",void 0);return a=d([c.subclass("esri.views.2d.actions.Rotate")],a)}(c.declared(q))});