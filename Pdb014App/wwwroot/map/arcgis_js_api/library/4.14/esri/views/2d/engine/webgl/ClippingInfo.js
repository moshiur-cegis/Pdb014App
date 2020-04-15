// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/tsSupport/extendsHelper ../../../../core/Error ../../../../core/Logger ../../../../core/maybe ../DisplayObject ./Mesh2D ../../../webgl/VertexArrayObject".split(" "),function(g,l,m,n,p,k,q,h,r){Object.defineProperty(l,"__esModule",{value:!0});var t=p.getLogger("esri.views.2d.engine.webgl.ClippingInfo");g=function(g){function b(d,a){var c=g.call(this)||this;c._cache={};c.parent=d;c._handle=a.watch("version",function(){return c._invalidate()});c._clip=a;c.attach();
c.attached=!0;return c}m(b,g);b.fromClipArea=function(d,a){return new b(d,a)};b.prototype._destroyGL=function(){k.isSome(this._cache.mesh)&&(this._cache.mesh.destroy(),this._cache.mesh=null);k.isSome(this._cache.vao)&&(this._cache.vao.dispose(),this._cache.vao=null)};b.prototype.destroy=function(){this._destroyGL();this._handle.remove()};b.prototype.doRender=function(){};b.prototype.getVAO=function(d,a,c,b){var e=a.size,f=e[0],e=e[1];if("geometry"===this._clip.type||this._lastWidth!==f||this._lastHeight!==
e)this._lastWidth=f,this._lastHeight=e,this._destroyGL();k.isNone(this._cache.vao)&&(a=this._createMesh(a,this._clip),f=a.getIndexBuffer(d),e=a.getVertexBuffers(d),this._cache.mesh=a,this._cache.vao=new r(d,c,b,e,f));return this._cache.vao};b.prototype._invalidate=function(){this._destroyGL();this.requestRender()};b.prototype._createScreenRect=function(d,a){var c=d.size;d=c[0];var c=c[1],b="string"===typeof a.left?parseFloat(a.left)/100*d:a.left,e="string"===typeof a.right?parseFloat(a.right)/100*
d:a.right,f="string"===typeof a.top?parseFloat(a.top)/100*c:a.top;a="string"===typeof a.bottom?parseFloat(a.bottom)/100*c:a.bottom;return{x:b,y:f,width:Math.max(d-e-b,0),height:Math.max(c-a-f,0)}};b.prototype._createMesh=function(b,a){switch(a.type){case "rect":return h.default.fromRect(this._createScreenRect(b,a));case "path":return h.default.fromPath(a);case "geometry":return h.default.fromGeometry(b,a);default:return t.error(n("mapview-bad-type","Unable to create ClippingInfo mesh from clip of type: ${clip.type}")),
h.default.fromRect({x:0,y:0,width:1,height:1})}};return b}(q.DisplayObject);l.default=g});