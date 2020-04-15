// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/tsSupport/extendsHelper dojox/string/BidiEngine ./Bucket ./GeometryUtils ./Placement ./style/StyleLayer ../webgl/Geometry ../webgl/TextShaping".split(" "),function(Q,R,L,M,N,y,E,I,C,O){function P(y,h){return y.iconMosaicItem&&h.iconMosaicItem?y.iconMosaicItem.page===h.iconMosaicItem.page?0:y.iconMosaicItem.page<h.iconMosaicItem.page?-1:1:y.iconMosaicItem&&!h.iconMosaicItem?1:!y.iconMosaicItem&&h.iconMosaicItem?-1:0}(function(){return function(){}})();return function(K){function h(a,
b,d,e,g,c,f,p){b=K.call(this,a,b)||this;b._markerMap=new Map;b._glyphMap=new Map;b._glyphBufferDataStorage=new Map;b._sdfMarkers=!1;if(a.hasDataDrivenIcon!==d.isDataDriven())throw Error("incompatible icon buffer");if(a.hasDataDrivenText!==g.isDataDriven())throw Error("incompatible text buffer");b._iconVertexBuffer=d;b._iconIndexBuffer=e;b._textVertexBuffer=g;b._textIndexBuffer=c;b._placementEngine=f;b._workerTileHandler=p;return b}L(h,K);Object.defineProperty(h.prototype,"markerPageMap",{get:function(){return this._markerMap},
enumerable:!0,configurable:!0});Object.defineProperty(h.prototype,"glyphsPageMap",{get:function(){return this._glyphMap},enumerable:!0,configurable:!0});Object.defineProperty(h.prototype,"sdfMarker",{get:function(){return this._sdfMarkers},enumerable:!0,configurable:!0});h.prototype.copy=function(a,b,d,e,g){a=new h(this.layer,this.zoom,a,b,d,e,g,this._workerTileHandler);a.layerIndex=this.layerIndex;a.layerExtent=this.layerExtent;a._iconIndexStart=b.index;a._textIndexStart=e.index;a._iconIndexCount=
0;a._textIndexCount=0;a._symbolInstances=this._symbolInstances;a._workerTileHandler=this._workerTileHandler;a._fontArray=this._fontArray;a._textLayout=this._textLayout;a._iconLayout=this._iconLayout;a._isLinePlacement=this._isLinePlacement;a._avoidEdges=this._avoidEdges;return a};h.prototype.getResources=function(a,b,d){var e=this.layer,g=this.zoom,c=e.hasDataDrivenIcon,f=e.hasDataDrivenText;a&&a.setExtent(this.layerExtent);for(var p=e.getLayoutProperty("icon-image"),n=e.getLayoutProperty("text-field"),
k=e.getLayoutValue("text-font",g),w=e.getLayoutValue("text-transform",g),q=[],l=[1,1,1,1],x=1,m=1,u=[1,1,1,1],r=1,t=1,A=0,z=this._features;A<z.length;A++){var v=z[A],y=v.getGeometry(a);if(y&&0!==y.length){var D=void 0;p&&(D=e.getLayoutValue("icon-image",g,v),p.isDataDriven||(D=this._replaceKeys(D,v.values)),D&&b.add(D));var B=void 0,C=!1;if(n&&(B=e.getLayoutValue("text-field",g,v),n.isDataDriven||(B=this._replaceKeys(B,v.values)),B=B.replace(/\\n/g,"\n"))){switch(w){case 2:B=B.toLowerCase();break;
case 1:B=B.toUpperCase()}h._bidiEngine.hasBidiChar(B)&&(C=void 0,C="rtl"===h._bidiEngine.checkContextual(B)?"IDNNN":"ICNNN",B=h._bidiEngine.bidiTransform(B,C,"VLYSN"),C=!0);var H=B.length;if(0<H)for(var F=0,E=k;F<E.length;F++){var G=E[F],J=d[G];J||(J=d[G]=new Set);for(G=0;G<H;G++){var I=B.charCodeAt(G);J.add(I)}}}if(D||B)H=e.getLayoutValue("icon-size",g,v),F=e.getLayoutValue("text-size",g,v),e.hasDataDrivenIconColor&&(l=e.getPaintValue("icon-color",g,v)),e.hasDataDrivenIconOpacity&&(x=e.getPaintValue("icon-opacity",
g,v)),e.hasDataDrivenIconSize&&(m=H),e.hasDataDrivenTextColor&&(u=e.getPaintValue("text-color",g,v)),e.hasDataDrivenTextOpacity&&(r=e.getPaintValue("text-opacity",g,v)),e.hasDataDrivenTextSize&&(t=F),v={sprite:D,label:B,rtl:C,type:v.type,geometry:y,iconSize:H,iconRotate:e.getLayoutValue("icon-rotate",g,v),ddIconValues:c?{color:l,opacity:x,size:m}:null,textSize:F,textRotate:e.getLayoutValue("text-rotate",g,v),ddTextValues:f?{color:u,opacity:r,size:t}:null},q.push(v)}}this._symbolFeatures=q};h.prototype.processFeatures=
function(a){a&&a.setExtent(this.layerExtent);var b=this.layer,d=this.zoom;a=this._isLinePlacement=1===b.getLayoutValue("symbol-placement",d);var e=8*b.getLayoutValue("symbol-spacing",d),g=b.getLayoutProperty("icon-image"),c=b.getLayoutProperty("text-field"),f=this._workerTileHandler,p,n;g&&(this._iconLayout=new I.IconLayout(b,d,a),p=f.getSpriteItems(),n=this._getTranslate(!0));var k,w,q;if(c){k=this._textLayout=new I.TextLayout(b,d,a);this._fontArray=k.fontArray;q=.5;switch(k.anchor){case 5:case 1:case 7:q=
0;break;case 6:case 2:case 8:q=1}w=.5;switch(k.anchor){case 5:case 3:case 6:w=0;break;case 7:case 4:case 8:w=1}b=.5;switch(k.justify){case 0:b=0;break;case 2:b=1}var d=24*k.letterSpacing,g=a?0:24*k.maxWidth,c=24*k.lineHeight,l=[24*k.offset[0],24*k.offset[1]];k=this._fontArray.map(function(a){return f.getGlyphItems(a)});w=new O.TextShaping(k,g,c,d,l,q,w,b);q=this._getTranslate(!1)}this._iconIndexStart=this._iconIndexBuffer.index;this._textIndexStart=this._textIndexBuffer.index;this._textIndexCount=
this._iconIndexCount=0;this._markerMap.clear();this._glyphMap.clear();this._symbolInstances=b=[];d=this._textLayout;g=1;d&&d.size&&(g=d.size/24);c=d?d.maxAngle*y.C_DEG_TO_RAD:0;k=d?8*d.size:0;for(var l=0,x=this._symbolFeatures;l<x.length;l++){var m=x[l],u=void 0;m.sprite&&(u=p[m.sprite])&&u.sdf&&(this._sdfMarkers=!0);var r=void 0,t=m.label,A=0;if(t&&(r=w.getShaping(t,m.rtl))&&0<r.length){for(var A=1E30,t=-1E30,z=0,v=r;z<v.length;z++)var C=v[z],A=Math.min(A,C.x),t=Math.max(t,C.x);A=(t-A+48)*g*8}t=
0;for(z=m.geometry;t<z.length;t++){var v=z[t],D=void 0;a?(r&&0<r.length&&d&&d.size&&h._smoothVertices(v,8*d.size*(2+Math.min(2,4*Math.abs(d.offset[1])))),D=h._findAnchors(v,e,A)):D=3===m.type?h._findCentroid(v):[new E.Anchor(v[0].x,v[0].y)];for(C=0;C<D.length;C++){var B=D[C];0>B.x||4096<B.x||0>B.y||4096<B.y||a&&0<A&&0===d.rotationAlignment&&!h._honorsTextMaxAngle(v,B,A,c,k)||b.push({shaping:r,line:v,iconMosaicItem:u,anchor:B,iconSize:m.iconSize,iconRotate:m.iconRotate,ddIconValues:m.ddIconValues,
textSize:m.textSize,textRotate:m.textRotate,ddTextValues:m.ddTextValues})}}}b.sort(P);for(p=0;p<b.length;p++)this._processFeature(b[p],n,q);this._addPlacedGlyphs()};h.prototype.updateSymbols=function(){this._iconIndexStart=this._iconIndexBuffer.index;this._textIndexStart=this._textIndexBuffer.index;this._textIndexCount=this._iconIndexCount=0;this._markerMap.clear();this._glyphMap.clear();var a=this.layer,b;a.getLayoutProperty("icon-image")&&(b=this._getTranslate(!0));var d;a.getLayoutProperty("text-field")&&
(d=this._getTranslate(!1));for(var a=0,e=this._symbolInstances;a<e.length;a++)this._processFeature(e[a],b,d);this._addPlacedGlyphs()};h.prototype.assignBufferInfo=function(){};h.prototype._getTranslate=function(a){var b=this.layer.getPaintValue(a?"icon-translate":"text-translate",this.zoom);if(0!==b[0]||0!==b[1]){var d=this._placementEngine.mapAngle;return 0!==d&&0===this.layer.getPaintValue(a?"icon-translate-anchor":"text-translate-anchor",this.zoom)?(a=Math.sin(d),d=Math.cos(d),[8*(b[0]*d-b[1]*
a),8*(b[0]*a+b[1]*d)]):[8*b[0],8*b[1]]}};h.prototype._replaceKeys=function(a,b){return a.replace(/{([^{}]+)}/g,function(a,e){return e in b?b[e]:""})};h.prototype._processFeature=function(a,b,d){var e=a.line,g=a.iconMosaicItem,c=a.shaping,f=a.anchor,p=this._iconLayout,n=p&&!!g,k=!0,w=1;n&&(p.size=a.iconSize,p.rotate=a.iconRotate,w=8*p.size,k=p.optional||!g);var q=this._textLayout,l=q&&c&&0<c.length,h;h=1;var m=!0;l&&(q.size=a.textSize,q.rotate=a.textRotate,h=q.size/24,h*=8,m=q.optional||!c||0===c.length);
var u=new C.Point(0,-17),r;n&&(r=this._placementEngine.getIconPlacement(f,b,g,w,p),f.minzoom>r.footprint.minzoom&&(r.footprint.minzoom=f.minzoom),r.footprint.minzoom===y.C_INFINITY&&(r=null));if(r||k){var t;l&&(t=this._placementEngine.getTextPlacement(f,d,u,c,h,e,q))&&(f.minzoom>t.footprint.minzoom&&(t.footprint.minzoom=f.minzoom),t.footprint.minzoom===y.C_INFINITY&&(t=null));if(t||m)r&&t||(m||k?m||t?k||r||(t=null):r=null:t=r=null),r&&t&&!m&&!k&&(b=Math.max(r.footprint.minzoom,t.footprint.minzoom),
r.footprint.minzoom=b,t.footprint.minzoom=b),t&&(q.ignorePlacement||this._placementEngine.add(t),this._storePlacedGlyphs(t.shapes,t.footprint.minzoom,this.zoom,a.ddTextValues)),r&&(p.ignorePlacement||this._placementEngine.add(r),this._addPlacedIcons(r.shapes,r.footprint.minzoom,this.zoom,g.page,a.ddIconValues))}};h.prototype._addPlacedIcons=function(a,b,d,e,g){b=Math.max(d+y.log2(b),0);for(var c=this._iconVertexBuffer,f=this._iconIndexBuffer,p=0;p<a.length;p++){var n=a[p],k=Math.max(d+y.log2(n.minzoom),
b),h=Math.min(d+y.log2(n.maxzoom),25);if(!(h<=k)){var q=n.tl,l=n.tr,x=n.bl,m=n.br,u=n.mosaicRect,r=n.labelAngle,n=n.anchor,t=c.index,A=u.x,z=u.y,v=A+u.width,u=z+u.height;c.add(n.x,n.y,q.x,q.y,A,z,r,k,h,b,g);c.add(n.x,n.y,l.x,l.y,v,z,r,k,h,b,g);c.add(n.x,n.y,x.x,x.y,A,u,r,k,h,b,g);c.add(n.x,n.y,m.x,m.y,v,u,r,k,h,b,g);f.add(t+0,t+1,t+2);f.add(t+1,t+2,t+3);this._markerMap.has(e)?this._markerMap.get(e)[1]+=6:this._markerMap.set(e,[this._iconIndexStart+this._iconIndexCount,6]);this._iconIndexCount+=2}}};
h.prototype._addPlacedGlyphs=function(){var a=this,b=this._textVertexBuffer,d=this._textIndexBuffer;this._glyphBufferDataStorage.forEach(function(e,g){for(var c=0;c<e.length;c++){var f=e[c],p=b.index;b.add(f.glyphAnchor[0],f.glyphAnchor[1],f.tl[0],f.tl[1],f.xmin,f.ymin,f.labelAngle,f.minLod,f.maxLod,f.placementLod,f.ddValues);b.add(f.glyphAnchor[0],f.glyphAnchor[1],f.tr[0],f.tr[1],f.xmax,f.ymin,f.labelAngle,f.minLod,f.maxLod,f.placementLod,f.ddValues);b.add(f.glyphAnchor[0],f.glyphAnchor[1],f.bl[0],
f.bl[1],f.xmin,f.ymax,f.labelAngle,f.minLod,f.maxLod,f.placementLod,f.ddValues);b.add(f.glyphAnchor[0],f.glyphAnchor[1],f.br[0],f.br[1],f.xmax,f.ymax,f.labelAngle,f.minLod,f.maxLod,f.placementLod,f.ddValues);d.add(p+0,p+1,p+2);d.add(p+1,p+2,p+3);a._glyphMap.has(g)?a._glyphMap.get(g)[1]+=6:a._glyphMap.set(g,[a._textIndexStart+a._textIndexCount,6]);a._textIndexCount+=2}});this._glyphBufferDataStorage.clear()};h.prototype._storePlacedGlyphs=function(a,b,d,e){b=Math.max(d+y.log2(b),0);for(var g=0;g<a.length;g++){var c=
a[g],f=Math.max(d+y.log2(c.minzoom),b),p=Math.min(d+y.log2(c.maxzoom),25);if(!(p<=f)){var n=c.tl,k=c.tr,h=c.bl,q=c.br,l=c.labelAngle,x=c.anchor,m=c.mosaicRect;this._glyphBufferDataStorage.has(c.page)||this._glyphBufferDataStorage.set(c.page,[]);this._glyphBufferDataStorage.get(c.page).push({glyphAnchor:[x.x,x.y],tl:[n.x,n.y],tr:[k.x,k.y],bl:[h.x,h.y],br:[q.x,q.y],xmin:m.x,ymin:m.y,xmax:m.x+m.width,ymax:m.y+m.height,labelAngle:l,minLod:f,maxLod:p,placementLod:b,ddValues:e})}}};h._findAnchors=function(a,
b,d){b+=d;for(var e=0,g=a.length-1,c=0;c<g;c++)e+=C.Point.distance(a[c],a[c+1]);c=.5*(d||b);if(e<=c)return[];d=c/e;b=e/Math.max(Math.round(e/b),1);for(var e=0,g=-b/2,f=[],p=a.length-1,c=0;c<p;c++){for(var n=a[c],k=a[c+1],h=k.x-n.x,q=k.y-n.y,l=Math.sqrt(h*h+q*q),x=void 0;g+b<e+l;){var g=g+b,m=(g-e)/l,u=y.interpolate(n.x,k.x,m),m=y.interpolate(n.y,k.y,m);void 0===x&&(x=Math.atan2(q,h));f.push(new E.Anchor(u,m,x,c,d))}e+=l}return f};h._deviation=function(a,b,d){return Math.atan2((b.x-a.x)*(d.y-b.y)-
(b.y-a.y)*(d.x-b.x),(b.x-a.x)*(d.x-b.x)+(b.y-a.y)*(d.y-b.y))};h._honorsTextMaxAngle=function(a,b,d,e,g){var c=0;d/=2;for(var f=new C.Point(b.x,b.y),p=b.segment+1;c>-d;){--p;if(0>p)return!1;c-=C.Point.distance(a[p],f);f=a[p]}c+=C.Point.distance(a[p],a[p+1]);b=[];for(var f=0,h=a.length;c<d;){var k=a[p],w=void 0;do{++p;if(p===h)return!1;w=a[p]}while(w.isEqual(k));var q=p,l=void 0;do{++q;if(q===h)return!1;l=a[q]}while(l.isEqual(w));k=this._deviation(k,w,l);b.push({deviation:k,distToAnchor:c});for(f+=
k;c-b[0].distToAnchor>g;)f-=b.shift().deviation;if(Math.abs(f)>e)return!1;c+=C.Point.distance(w,l)}return!0};h._smoothVertices=function(a,b){if(!(0>=b)){var d=a.length;if(!(3>d)){var e=[],g=0;e.push(0);for(var c=1;c<d;c++)g+=C.Point.distance(a[c],a[c-1]),e.push(g);b=Math.min(b,.2*g);g=[];g.push(a[0].x);g.push(a[0].y);var f=a[d-1].x,h=a[d-1].y,c=C.Point.sub(a[0],a[1]);c.normalize();a[0].x+=b*c.x;a[0].y+=b*c.y;c.assignSub(a[d-1],a[d-2]);c.normalize();a[d-1].x+=b*c.x;a[d-1].y+=b*c.y;for(c=1;c<d;c++)e[c]+=
b;e[d-1]+=b;for(var n=.5*b,c=1;c<d-1;c++){for(var k=0,w=0,q=0,l=c-1;0<=l&&!(e[l+1]<e[c]-n);l--){var x=n+e[l+1]-e[c],m=e[l+1]-e[l],u=e[c]-e[l]<n?1:x/m;if(1E-6>Math.abs(u))break;var r=u*u,t=u*x-.5*r*m,A=u*m/b,z=a[l+1],v=a[l].x-z.x,y=a[l].y-z.y,k=k+A/t*(z.x*u*x+.5*r*(x*v-m*z.x)-r*u*m*v/3),w=w+A/t*(z.y*u*x+.5*r*(x*y-m*z.y)-r*u*m*y/3),q=q+A}for(l=c+1;l<d&&!(e[l-1]>e[c]+n);l++){x=n-e[l-1]+e[c];m=e[l]-e[l-1];u=e[l]-e[c]<n?1:x/m;if(1E-6>Math.abs(u))break;r=u*u;t=u*x-.5*r*m;A=u*m/b;z=a[l-1];v=a[l].x-z.x;y=
a[l].y-z.y;k+=A/t*(z.x*u*x+.5*r*(x*v-m*z.x)-r*u*m*v/3);w+=A/t*(z.y*u*x+.5*r*(x*y-m*z.y)-r*u*m*y/3);q+=A}g.push(k/q);g.push(w/q)}g.push(f);g.push(h);for(l=c=0;c<d;c++)a[c].x=g[l++],a[c].y=g[l++]}}};h._findCentroid=function(a){var b=a.length-1,d=0,e=0,g=0,c=a[0].x,f=a[0].y;4096<c&&(c=4096);0>c&&(c=0);4096<f&&(f=4096);0>f&&(f=0);for(var h=1;h<b;h++){var n=a[h].x,k=a[h].y,w=a[h+1].x,q=a[h+1].y;4096<n&&(n=4096);0>n&&(n=0);4096<k&&(k=4096);0>k&&(k=0);4096<w&&(w=4096);0>w&&(w=0);4096<q&&(q=4096);0>q&&(q=
0);var l=(n-c)*(q-f)-(w-c)*(k-f),d=d+l*(c+n+w),e=e+l*(f+k+q),g=g+l}d/=3*g;e/=3*g;return isNaN(d)||isNaN(e)?[]:[new E.Anchor(d,e)]};h._bidiEngine=new M;return h}(N)});