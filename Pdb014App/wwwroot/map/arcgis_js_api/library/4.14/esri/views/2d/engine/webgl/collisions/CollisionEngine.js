// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../../core/Error ../../../../../core/iteratorUtils ../../../../../core/Logger ../../../../../core/mathUtils ../definitions ./CollisionBucket ./LayerCollisionInfo".split(" "),function(v,w,y,x,z,n,r,A,l){Object.defineProperty(w,"__esModule",{value:!0});var t=r.TILE_SIZE/r.COLLISION_BUCKET_SIZE,B=z.getLogger("esri.views.2d.engine.webgl.collisions.CollisionEngine");v=function(){function c(a){this._layers=new Map;this._collisionBuckets=new Map;this._didError=!1;this._tilingScheme=
a}Object.defineProperty(c.prototype,"collisionInfos",{get:function(){return x.valuesOfMap(this._layers)},enumerable:!0,configurable:!0});c.prototype.registerLayerView=function(a,b){if(!this._layers.has(a)){var d=l.default.create(a,b,this.collisionInfos,this._tilingScheme);this._layers.set(a,d);this._collisionBuckets.forEach(function(a){return a.onRegisterLayer(d.index)})}};c.prototype.unregisterLayerView=function(a){var b=this;if(this._layers.has(a)){var d=this._layers.get(a);l.default.delete(d.index,
this.collisionInfos);this._layers.delete(a);this._collisionBuckets.forEach(function(a,m){var f=a.getTile(d.index);f&&(a.onUnregisterLayer(d.index),a.canDelete()&&b._collisionBuckets.delete(m),f.reference&&(f.reference.isDirty=!1))})}};c.prototype.addTile=function(a,b){var d=b.key.id;this._layers.has(a)&&(this._collisionBuckets.has(d)||this._collisionBuckets.set(d,new A.default(b.key,this._layers.size)),a=this._getIndex(a),this._collisionBuckets.get(d).getTile(a).reference=b)};c.prototype.removeTile=
function(a,b){this._layers.has(a)&&this._collisionBuckets.has(b)&&(a=this._getIndex(a),b=this._collisionBuckets.get(b).getTile(a),b.dirty=!1,b.reference=null)};c.prototype.run=function(a,b){var d=x.valuesOfMap(this._collisionBuckets).sort(function(a,b){return a.key.compareRowMajor(b.key)}),f=!0,m=a.renderingOptions.labelCollisionsEnabled&&!this._didError,c=this.collisionInfos;try{for(var h=0;h<d.length;h++)for(var e=d[h],f=f||e.isDirty,k=0;k<this._layers.size;k++){var g=l.default.find(k,c);e.computeNeighbors(this._collisionBuckets);
e.reset(a,f,g)}for(a=0;a<this._layers.size;a++)for(g=l.default.find(a,c),f=0,h=d;f<h.length;f++)e=h[f],this._run(m,e,g,b)}catch(p){B.error(y("mapview-labeling","Encountered an error during decluttering. Disabling collisions",p)),this._didError=!0}for(b=0;b<d.length;b++)e=d[b],e.ready()};c.prototype._run=function(a,b,d,f){var c=b.getReference(d.index);c&&c.hasData&&(c.key.level!==f?this._resetLabelsMinZoom(b,d):this._runVisibility(a,b,c,d,f))};c.prototype._resetLabelsMinZoom=function(a,b){if(a&&"polyline"!==
b.geometryType&&(a=a.getReference(b.index))&&a.hasData){b=b.layerView.tileRenderer.featuresView.attributeView;var d=0;for(a=a.displayObjects;d<a.length;d++)b.setLabelMinZoom(a[d].id,255)}};c.prototype._checkLabelsVisible=function(a,b){var d=!b.effect||b.effect.excludedLabelsVisible||!!(a&r.EFFECT_FLAG_0);return(!b.filter||!!(a&r.FILTER_FLAG_0))&&d};c.prototype._runVisibility=function(a,b,d,f,c){var m=f.layerView.tileRenderer.featuresView.attributeView,h=0;for(d=d.displayObjects.sort(function(a,b){a=
m.getLabelMinZoom(a.id);b=m.getLabelMinZoom(b.id);return a-b});h<d.length;h++){var e=d[h];if(e.metrics.length){var k="polyline"===f.geometryType?0:10*(c-1),g=m.getFilterFlags(e.id),p=this._checkLabelsVisible(g,f.layerView);if(a)for(var q=0;q<e.metrics.length;q++)g=e.metrics[q],g=p?-1!==g.minZoom?g.minZoom:this._computeLabelVisibility(e,g,f.index,b,g.baseZoom,c):255,k=Math.max(g,k);m.setLabelMinZoom(e.id,k);p=0;for(e=e.metrics;p<e.length;p++)g=e[p],g.minZoom=k}}};c.prototype._computeLabelVisibility=
function(a,b,d,f,c,r){for(var h=b.xBucket,e=b.yBucket,k=b.xOverflow,g=b.yOverflow,m=h-k,h=h+k+1,k=e+g+1,e=e-g;e<k;e++)for(g=m;g<h;g++)if(!(g<-t||e<-t||g>t||e>t))for(var q=0;q<=d;q++){var l=this._getRelativeSubBucket(q,f,g,e);if(l)for(var n=0;n<l.length;n++){var u=l[n];u.id!==a.id&&(u=this._compareLabels(b,u,c,r),c=Math.max(u,c))}}return c};c.prototype._compareLabels=function(a,b,d,c){if(-1===b.minZoom||b.minZoom>10*(c+1))return d;a=a.findCollisionDelta(b);c=n.clamp(Math.floor(10*(a+c)),0,255);return b.minZoom>=
c?d:Math.max(d,c)};c.prototype._getNeighboringTile=function(a,b,d,c){return(b=b.neighbors[3*(1+c)+(1+d)])&&b.getTile(a)};c.prototype._getRelativeSubBucket=function(a,b,d,c){var f=n.sign(Math.floor(d/4)),l=n.sign(Math.floor(c/4));return(a=this._getNeighboringTile(a,b,f,l))&&a.reference&&a.index&&a.reference.hasData?a.index[c-4*l][d-4*f]:null};c.prototype._getIndex=function(a){return this._layers.get(a).index};return c}();w.CollisionEngine=v});