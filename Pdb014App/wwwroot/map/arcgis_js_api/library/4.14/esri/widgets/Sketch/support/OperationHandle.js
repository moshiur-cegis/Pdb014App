// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/tsSupport/declareExtendsHelper ../../../core/tsSupport/decorateHelper ../../../core/compilerUtils ../../../core/Evented ../../../core/accessorSupport/decorators".split(" "),function(e,f,g,c,h,k,b){Object.defineProperty(f,"__esModule",{value:!0});e=function(d){function a(){var a=null!==d&&d.apply(this,arguments)||this;a.cancelled=!1;a.history={undo:[],redo:[]};a.type=null;return a}g(a,d);Object.defineProperty(a.prototype,"tool",{get:function(){if(!this.activeComponent)return null;
switch(this.activeComponent.type){case "graphic-mover":case "move-3d":return"move";case "box":case "transform-3d":return"transform";case "reshape":case "reshape-3d":return"reshape";case "draw":break;default:h.neverReached(this.activeComponent)}return null},enumerable:!0,configurable:!0});a.prototype.addToHistory=function(a){this.history.redo=[];this.history.undo.push(a)};a.prototype.resetHistory=function(){this.history.redo=[];this.history.undo=[]};a.prototype.canUndo=function(){return 0<this.history.undo.length};
a.prototype.canRedo=function(){return 0<this.history.redo.length};a.prototype.complete=function(){this.reset();this.onEnd();this.emit("complete")};a.prototype.cancel=function(){this._set("cancelled",!0);this.reset();this.onEnd();this.emit("cancel")};a.prototype.reset=function(){this.activeComponent.reset()};a.prototype.refreshComponent=function(){var a=this.activeComponent;a&&("box"!==a.type&&"reshape"!==a.type||a.refresh())};Object.defineProperty(a.prototype,"undo",{set:function(a){var b=this;this._set("undo",
function(){b.canUndo()&&a()})},enumerable:!0,configurable:!0});Object.defineProperty(a.prototype,"redo",{set:function(a){var b=this;this._set("redo",function(){b.canRedo()&&a()})},enumerable:!0,configurable:!0});c([b.property()],a.prototype,"activeComponent",void 0);c([b.property()],a.prototype,"cancelled",void 0);c([b.property()],a.prototype,"history",void 0);c([b.property({dependsOn:["activeComponent"]})],a.prototype,"tool",null);c([b.property()],a.prototype,"type",void 0);c([b.property()],a.prototype,
"canUndo",null);c([b.property()],a.prototype,"canRedo",null);c([b.property()],a.prototype,"onEnd",void 0);c([b.property()],a.prototype,"undo",null);c([b.property()],a.prototype,"redo",null);c([b.property()],a.prototype,"toggleTool",void 0);c([b.property()],a.prototype,"addToSelection",void 0);c([b.property()],a.prototype,"removeFromSelection",void 0);return a=c([b.subclass("esri.widgets.Sketch.support.OperationHandle")],a)}(b.declared(k.EventedAccessor));f.OperationHandle=e});