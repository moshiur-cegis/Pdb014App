// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/tsSupport/declareExtendsHelper ../../../core/tsSupport/decorateHelper ../../../core/JSONSupport ../../../core/accessorSupport/decorators ../../../core/accessorSupport/ensureType ../../../webdoc/support/opacityUtils".split(" "),function(l,m,g,c,h,b,k,e){return function(f){function a(a){a=f.call(this,a)||this;a.label=null;a.opacity=null;a.value=null;return a}g(a,f);d=a;a.prototype.readOpacity=function(a,b){return e.transparencyToOpacity(b.transparency)};a.prototype.writeOpacity=
function(a,b,c){b[c]=e.opacityToTransparency(a)};a.prototype.clone=function(){return new d({label:this.label,opacity:this.opacity,value:this.value})};var d;c([b.property({type:String,json:{write:!0}})],a.prototype,"label",void 0);c([b.property({type:Number,json:{type:k.Integer,write:{target:"transparency"}}})],a.prototype,"opacity",void 0);c([b.reader("opacity",["transparency"])],a.prototype,"readOpacity",null);c([b.writer("opacity")],a.prototype,"writeOpacity",null);c([b.property({type:Number,json:{write:!0}})],
a.prototype,"value",void 0);return a=d=c([b.subclass("esri.renderers.visualVariables.support.OpacityStop")],a)}(b.declared(h.JSONSupport))});