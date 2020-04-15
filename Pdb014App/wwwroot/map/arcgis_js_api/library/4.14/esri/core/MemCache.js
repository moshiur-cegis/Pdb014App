// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","./iteratorUtils","./PooledArray","./string"],function(f,h,n,p,k){Object.defineProperty(h,"__esModule",{value:!0});h.MIN_PRIORITY=-3;f=function(){function a(b,d,c){this._namespace=b;this._storage=d;this._removeFunc=!1;this._miss=this._hit=0;this._storage.register(this);this._namespace+=":";c&&(this._storage.registerRemoveFunc(this._namespace,c),this._removeFunc=!0)}Object.defineProperty(a.prototype,"namespace",{get:function(){return this._namespace.slice(0,-1)},enumerable:!0,
configurable:!0});Object.defineProperty(a.prototype,"hitRate",{get:function(){return this._hit/(this._hit+this._miss)},enumerable:!0,configurable:!0});Object.defineProperty(a.prototype,"size",{get:function(){return this._storage.size},enumerable:!0,configurable:!0});Object.defineProperty(a.prototype,"maxSize",{get:function(){return this._storage.maxSize},enumerable:!0,configurable:!0});a.prototype.resetHitRate=function(){this._hit=this._miss=0};a.prototype.destroy=function(){this._storage.clear(this._namespace);
this._removeFunc&&this._storage.deregisterRemoveFunc(this._namespace);this._storage.deregister(this)};a.prototype.put=function(b,d,c,a){void 0===a&&(a=0);this._storage.put(this._namespace+b,d,c,a)};a.prototype.get=function(b){b=this._storage.get(this._namespace+b);void 0===b?++this._miss:++this._hit;return b};a.prototype.pop=function(b){b=this._storage.pop(this._namespace+b);void 0===b?++this._miss:++this._hit;return b};a.prototype.updateSize=function(b,d,c){this._storage.updateSize(this._namespace+
b,d,c)};a.prototype.clear=function(){this._storage.clear(this._namespace)};a.prototype.clearAll=function(){this._storage.clearAll()};a.prototype.getStats=function(){return this._storage.getStats()};a.prototype.resetStats=function(){this._storage.resetStats()};return a}();h.MemCache=f;f=function(){function a(b){void 0===b&&(b=10485760);this._maxSize=b;this._db=new Map;this._miss=this._hit=this._size=0;this._removeFuncs=[];this._users=new p}a.prototype.register=function(b){this._users.push(b)};a.prototype.deregister=
function(b){this._users.removeUnordered(b)};a.prototype.registerRemoveFunc=function(b,d){this._removeFuncs.push([b,d])};a.prototype.deregisterRemoveFunc=function(b){this._removeFuncs=this._removeFuncs.filter(function(d){return d[0]!==b})};Object.defineProperty(a.prototype,"size",{get:function(){return this._size},enumerable:!0,configurable:!0});Object.defineProperty(a.prototype,"maxSize",{get:function(){return this._maxSize},set:function(b){this._maxSize=Math.max(b,0);this._checkSizeLimit()},enumerable:!0,
configurable:!0});a.prototype.put=function(b,d,c,a){var e=this._db.get(b);e&&(this._size-=e.size,this._db.delete(b),e.entry!==d&&this._notifyRemoved(b,e.entry));c>this._maxSize?this._notifyRemoved(b,d):void 0===d?console.warn("Refusing to cache undefined entry "):!c||0>c?console.warn("Refusing to cache entry with invalid size "+c):(a=1+Math.max(a,h.MIN_PRIORITY)-h.MIN_PRIORITY,this._db.set(b,{entry:d,size:c,lifetime:a,lives:a}),this._size+=c,this._checkSizeLimit())};a.prototype.updateSize=function(b,
d,a){var c=this._db.get(b);c&&c.entry===d&&(this._size-=c.size,a>this._maxSize?this._notifyRemoved(b,d):(c.size=a,this._size+=a,this._checkSizeLimit()))};a.prototype.pop=function(b){var a=this._db.get(b);if(a)return this._size-=a.size,this._db.delete(b),++this._hit,a.entry;++this._miss};a.prototype.get=function(b){var a=this._db.get(b);if(void 0===a)++this._miss;else return this._db.delete(b),a.lives=a.lifetime,this._db.set(b,a),++this._hit,a.entry};a.prototype.getStats=function(){var b=this,a={Size:Math.round(this._size/
1048576)+"/"+Math.round(this._maxSize/1048576)+"MB","Hit rate":Math.round(100*this._getHitRate())+"%",Entries:this._db.size.toString()},c={},e=[];this._db.forEach(function(a,d){var l=a.lifetime;e[l]=(e[l]||0)+a.size;b._users.forEach(function(b){b=b.namespace;k.startsWith(d,b)&&(c[b]=(c[b]||0)+a.size)})});var f={};this._users.forEach(function(b){var a=b.namespace;!isNaN(b.hitRate)&&0<b.hitRate?(c[a]=c[a]||0,f[a]=Math.round(100*b.hitRate)+"%"):f[a]="0%"});var g=Object.keys(c);g.forEach(function(a){return c[a]=
c[a]/b._size*100});g.sort(function(b,a){return c[a]-c[b]});g.forEach(function(b){return a[b]=Math.round(c[b])+"% / "+f[b]});for(g=e.length-1;0<=g;--g){var m=e[g];m&&(a["Priority "+(g+h.MIN_PRIORITY-1)]=Math.round(m/this.size*100)+"%")}return a};a.prototype.resetStats=function(){this._hit=this._miss=0;this._users.forEach(function(b){return b.resetHitRate()})};a.prototype.clear=function(b){var a=this;this._db.forEach(function(c,d){k.startsWith(d,b)&&(a._size-=c.size,a._db.delete(d),a._notifyRemoved(d,
c.entry))})};a.prototype.clearAll=function(){var b=this;this._db.forEach(function(a,c){b._notifyRemoved(c,a.entry)});this._size=0;this._db.clear()};a.prototype._getHitRate=function(){return this._hit/(this._hit+this._miss)};a.prototype._notifyRemoved=function(a,d){this._removeFuncs.forEach(function(b){if(k.startsWith(a,b[0]))b[1](d)})};a.prototype._checkSizeLimit=function(){var a=this;this._size<=this._maxSize||n.someMap(this._db,function(b,c){a._db.delete(c);1>=b.lives?(a._size-=b.size,a._notifyRemoved(c,
b.entry)):(--b.lives,a._db.set(c,b));return a._size<=.9*a.maxSize})};return a}();h.MemCacheStorage=f});