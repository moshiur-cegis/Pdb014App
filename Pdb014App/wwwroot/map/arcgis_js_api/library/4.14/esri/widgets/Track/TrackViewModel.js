// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../core/tsSupport/declareExtendsHelper ../../core/tsSupport/decorateHelper ../../core/accessorSupport/decorators ../support/GeolocationPositioning".split(" "),function(h,k,f,d,c,g){return function(e){function a(b){b=e.call(this,b)||this;b._watchId=null;b._trackStartingTimeoutId=null;b._settingPosition=null;return b}f(a,e);a.prototype.destroy=function(){this._stopTracking()};Object.defineProperty(a.prototype,"state",{get:function(){return this._geolocationUsable?this.view&&
!this.view.ready?"disabled":this._settingPosition||null!==this._trackStartingTimeoutId?"waiting":this.tracking?"tracking":"ready":"feature-unsupported"},enumerable:!0,configurable:!0});Object.defineProperty(a.prototype,"tracking",{get:function(){return null!==this._watchId},enumerable:!0,configurable:!0});a.prototype.start=function(){"disabled"!==this.state&&"feature-unsupported"!==this.state&&this._startTracking()};a.prototype.stop=function(){"disabled"!==this.state&&"feature-unsupported"!==this.state&&
this._stopTracking()};a.prototype._stopWatchingPosition=function(){null!==this._watchId&&(navigator.geolocation.clearWatch(this._watchId),this._watchId=null)};a.prototype._stopTracking=function(){this._clearWaitingTimer();this._stopWatchingPosition();this._clear()};a.prototype._startTracking=function(){var b=this;this._stopTracking();var a=navigator.geolocation.watchPosition(function(c){b._watchId=a;b._settingPosition=b._setPosition(c).then(function(a){b._clearWaitingTimer();var c=b.view,d=b.graphic;
c&&c.graphics.remove(d);d&&(d=d.clone(),b.graphic=d,c&&c.graphics.push(d));b.emit("track",{position:a})}).catch(function(a){b._emitError(a);b._clearWaitingTimer();throw a;})},this._handleWatchPositionError.bind(this),this.geolocationOptions);this._trackStartingTimeoutId=setTimeout(function(){b._trackStartingTimeoutId=null},15E3)};a.prototype._handleWatchPositionError=function(a){this._emitError(a);this._stopTracking()};a.prototype._clearWaitingTimer=function(){clearTimeout(this._trackStartingTimeoutId);
this._settingPosition=this._trackStartingTimeoutId=null};a.prototype._emitError=function(a){this.emit("track-error",{error:a})};d([c.property()],a.prototype,"_watchId",void 0);d([c.property()],a.prototype,"_trackStartingTimeoutId",void 0);d([c.property()],a.prototype,"_settingPosition",void 0);d([c.property({dependsOn:["view.ready","tracking","_geolocationUsable","_trackStartingTimeoutId","_settingPosition"],readOnly:!0})],a.prototype,"state",null);d([c.property({readOnly:!0,dependsOn:["_watchId"]})],
a.prototype,"tracking",null);d([c.property()],a.prototype,"start",null);d([c.property()],a.prototype,"stop",null);return a=d([c.subclass("esri.widgets.Track.TrackViewModel")],a)}(c.declared(g))});