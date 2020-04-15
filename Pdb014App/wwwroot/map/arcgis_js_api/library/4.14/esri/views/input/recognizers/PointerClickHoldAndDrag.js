// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../core/tsSupport/extendsHelper ../../../core/clock ../InputHandler ./support".split(" "),function(l,h,m,n,p,q){Object.defineProperty(h,"__esModule",{value:!0});h.DefaultParameters={maximumClickDelay:300,movementUntilMouseDrag:1.5,movementUntilTouchDrag:6,holdDelay:500};l=function(k){function g(d,e,b,f,a){void 0===d&&(d=h.DefaultParameters.maximumClickDelay);void 0===e&&(e=h.DefaultParameters.movementUntilMouseDrag);void 0===b&&(b=h.DefaultParameters.movementUntilTouchDrag);
void 0===f&&(f=h.DefaultParameters.holdDelay);void 0===a&&(a=n.default);var c=k.call(this,!1)||this;c.maximumClickDelay=d;c.movementUntilMouseDrag=e;c.movementUntilTouchDrag=b;c.holdDelay=f;c._clock=a;c._pointerState=new Map;c._pointerDrag=c.registerOutgoing("pointer-drag");c._immediateClick=c.registerOutgoing("immediate-click");c._pointerHold=c.registerOutgoing("hold");c.registerIncoming("pointer-down",c._handlePointerDown.bind(c));c.registerIncoming("pointer-up",function(a){c._handlePointerLoss(a,
"pointer-up")});c.registerIncoming("pointer-capture-lost",function(a){c._handlePointerLoss(a,"pointer-capture-lost")});c.registerIncoming("pointer-cancel",function(a){c._handlePointerLoss(a,"pointer-cancel")});c._moveHandle=c.registerIncoming("pointer-move",c._handlePointerMove.bind(c));c._moveHandle.pause();return c}m(g,k);g.prototype.onUninstall=function(){this._pointerState.forEach(function(d){null!=d.holdTimeout&&(d.holdTimeout.remove(),d.holdTimeout=null)});k.prototype.onUninstall.call(this)};
g.prototype._handlePointerDown=function(d){var e=this,b=d.data,f=b.native.pointerId,a=null;0===this._pointerState.size&&(a=this._clock.setTimeout(function(){var a=e._pointerState.get(f);a&&(a.isDragging||(e._pointerHold.emit(a.previousEvent,void 0,d.modifiers),a.holdEmitted=!0),a.holdTimeout=null)},this.holdDelay));a={startEvent:b,previousEvent:b,startTimestamp:d.timestamp,isDragging:!1,downButton:b.native.button,holdTimeout:a,modifiers:new Set};this._pointerState.set(f,a);this.startCapturingPointer(b.native);
this._moveHandle.resume();1<this._pointerState.size&&this.startDragging(d)};g.prototype._createPointerDragData=function(d,e,b){return{action:d,startEvent:e.startEvent,previousEvent:e.previousEvent,currentEvent:b}};g.prototype._handlePointerMove=function(d){var e=d.data,b=this._pointerState.get(e.native.pointerId);b&&(b.isDragging?this._pointerDrag.emit(this._createPointerDragData("update",b,e),void 0,b.modifiers):q.euclideanDistance(e,b.startEvent)>("touch"===e.native.pointerType?this.movementUntilTouchDrag:
this.movementUntilMouseDrag)&&this.startDragging(d),b.previousEvent=e)};g.prototype.startDragging=function(d){var e=this,b=d.data,f=b.native.pointerId;this._pointerState.forEach(function(a){null!=a.holdTimeout&&(a.holdTimeout.remove(),a.holdTimeout=null);a.isDragging||(a.modifiers=d.modifiers,a.isDragging=!0,f===a.startEvent.native.pointerId?e._pointerDrag.emit(e._createPointerDragData("start",a,b)):e._pointerDrag.emit(e._createPointerDragData("start",a,a.previousEvent),d.timestamp))})};g.prototype._handlePointerLoss=
function(d,e){var b=d.data,f=b.native.pointerId,a=this._pointerState.get(f);a&&(null!=a.holdTimeout&&(a.holdTimeout.remove(),a.holdTimeout=null),a.isDragging?this._pointerDrag.emit(this._createPointerDragData("end",a,"pointer-up"===e?b:a.previousEvent),void 0,a.modifiers):"pointer-up"===e&&a.downButton===b.native.button&&d.timestamp-a.startTimestamp<=this.maximumClickDelay&&!a.holdEmitted&&this._immediateClick.emit(b),this._pointerState.delete(f),this.stopCapturingPointer(b.native),0===this._pointerState.size&&
this._moveHandle.pause())};return g}(p.InputHandler);h.PointerClickHoldAndDrag=l});