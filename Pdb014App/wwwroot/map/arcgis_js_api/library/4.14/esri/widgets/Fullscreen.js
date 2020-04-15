// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../core/tsSupport/declareExtendsHelper ../core/tsSupport/decorateHelper dojo/i18n!./Fullscreen/nls/Fullscreen ../core/accessorSupport/decorators ./Widget ./Fullscreen/FullscreenViewModel ./support/widget".split(" "),function(n,p,l,c,g,e,m,h,f){return function(k){function a(b){b=k.call(this,b)||this;b.element=null;b.label=g.widgetLabel;b.view=null;b.viewModel=new h;return b}l(a,k);a.prototype.render=function(){var b,a,d=this.get("viewModel.state"),c=(b={},b["esri-disabled"]=
"disabled"===d||"feature-unsupported"===d,b);b=(a={},a["esri-icon-zoom-out-fixed"]="ready"===d||"disabled"===d||"feature-unsupported"===d,a["esri-icon-zoom-in-fixed"]="active"===d,a);a="active"===d?g.exit:"ready"===d?g.enter:"";return f.tsx("div",{bind:this,class:this.classes("esri-fullscreen esri-widget--button esri-widget",c),role:"button",tabIndex:0,onclick:this._toggle,onkeydown:this._toggle,"aria-label":a,title:a},f.tsx("span",{class:this.classes("esri-icon",b),"aria-hidden":"true"}),f.tsx("span",
{class:"esri-icon-font-fallback-text"},a))};a.prototype._toggle=function(){this.viewModel.toggle()};c([e.aliasOf("viewModel.element")],a.prototype,"element",void 0);c([e.property()],a.prototype,"label",void 0);c([e.aliasOf("viewModel.view")],a.prototype,"view",void 0);c([e.property({type:h}),f.renderable("viewModel.state")],a.prototype,"viewModel",void 0);c([f.accessibleHandler()],a.prototype,"_toggle",null);return a=c([e.subclass("esri.widgets.Fullscreen")],a)}(e.declared(m))});