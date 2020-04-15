// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define(["require","exports","../../../../symbols/cim/enums","./mesh/templates/util"],function(n,m,p,z){function x(){if(b.cosine<d.innerBisectorAutoSplitThreshold){b.splitInner=!0;b.gapInner=!0;var c=Math.max(d.innerBisectorAutoSplitThreshold,b.cosine),c=Math.sqrt(1-c*c)/c;b.leftInner.x=b.nextNormal.x+b.sign*c*b.outbound.x;b.leftInner.y=b.nextNormal.y+b.sign*c*b.outbound.y;b.rightInner.x=b.prevNormal.x-b.sign*c*b.inbound.x;b.rightInner.y=b.prevNormal.y-b.sign*c*b.inbound.y}else d.enableInnerBisectorSplit&&
(b.splitInner=!0,b.gapInner=!1,b.leftInner.x=b.rightInner.x=b.bisector.x/b.cosine,b.leftInner.y=b.rightInner.y=b.bisector.y/b.cosine);b.cosine<d.outerBisectorAutoSplitThreshold?(b.splitOuter=!0,b.gapOuter=!0,c=Math.max(d.outerBisectorAutoSplitThreshold,b.cosine),c=Math.sqrt(1-c*c)/c,b.leftOuter.x=b.prevNormal.x-b.sign*c*b.inbound.x,b.leftOuter.y=b.prevNormal.y-b.sign*c*b.inbound.y,b.rightOuter.x=b.nextNormal.x+b.sign*c*b.outbound.x,b.rightOuter.y=b.nextNormal.y+b.sign*c*b.outbound.y):d.enableOuterBisectorSplit&&
(b.splitOuter=!0,b.gapOuter=!1,b.leftOuter.x=b.rightOuter.x=b.bisector.x/b.cosine,b.leftOuter.y=b.rightOuter.y=b.bisector.y/b.cosine)}function q(){if(t)b.distance=0,t=b.isCap=b.isFirstVertex=b.isLastVertex=!1;else{if(0===g)if(b.isFirstVertex=0===f,h=e[f],0===f){if(g=0,b.closed){b.inbound.x=h.x-e[e.length-2].x;b.inbound.y=h.y-e[e.length-2].y;var c=Math.sqrt(b.inbound.x*b.inbound.x+b.inbound.y*b.inbound.y);b.inbound.x/=c;b.inbound.y/=c}}else b.inbound.x=h.x-r.x,b.inbound.y=h.y-r.y,g=Math.sqrt(b.inbound.x*
b.inbound.x+b.inbound.y*b.inbound.y),b.inbound.x/=g,b.inbound.y/=g;b.distance+g-l<=d.wrapDistance?(f<e.length-1?(b.outbound.x=e[f+1].x-h.x,b.outbound.y=e[f+1].y-h.y,c=Math.sqrt(b.outbound.x*b.outbound.x+b.outbound.y*b.outbound.y),b.outbound.x/=c,b.outbound.y/=c):b.closed?(b.outbound.x=e[1].x-h.x,b.outbound.y=e[1].y-h.y,c=Math.sqrt(b.outbound.x*b.outbound.x+b.outbound.y*b.outbound.y),b.outbound.x/=c,b.outbound.y/=c):(b.outbound.x=b.inbound.x,b.outbound.y=b.inbound.y),0!==f||b.closed||(b.inbound.x=
b.outbound.x,b.inbound.y=b.outbound.y),++f,b.isLastVertex=f===e.length,b.isCap=!b.closed&&(b.isFirstVertex||b.isLastVertex),b.distance+=g-l,l=g=0,t=b.distance+g-l===d.wrapDistance,b.currentVertex.x=h.x,b.currentVertex.y=h.y,r=h,h=null):(b.outbound.x=b.inbound.x,b.outbound.y=b.inbound.y,l+=d.wrapDistance-b.distance,b.distance=d.wrapDistance,t=!0,c=l/g,b.currentVertex.x=(1-c)*r.x+c*h.x,b.currentVertex.y=(1-c)*r.y+c*h.y)}}function w(){b.prevNormal.x=-b.inbound.y;b.prevNormal.y=b.inbound.x;b.nextNormal.x=
-b.outbound.y;b.nextNormal.y=b.outbound.x}function u(){w();b.bisector.x=b.prevNormal.x+b.nextNormal.x;b.bisector.y=b.prevNormal.y+b.nextNormal.y;var c=Math.sqrt(b.bisector.x*b.bisector.x+b.bisector.y*b.bisector.y);.001>c?(b.bisector.x=void 0,b.bisector.y=void 0,b.cosine=0,b.sign=void 0):(b.bisector.x/=c,b.bisector.y/=c,b.cosine=b.bisector.x*b.nextNormal.x+b.bisector.y*b.nextNormal.y,b.sign=0<=b.prevNormal.x*b.nextNormal.y-b.prevNormal.y*b.nextNormal.x?1:-1)}function v(c){k.vertex(b);1===c?(b.leftEntry0=
b.entry0,b.leftEntry1=b.entry1,b.leftEntry2=b.entry2,b.leftExit0=b.exit0,b.leftExit1=b.exit1,b.leftExit2=b.exit2):2===c&&(b.rightEntry0=b.entry0,b.rightEntry1=b.entry1,b.rightEntry2=b.entry2,b.rightExit0=b.exit0,b.rightExit1=b.exit1,b.rightExit2=b.exit2)}function y(c){k.vertex(b);1===c?(b.leftEntry0=b.entry0,b.leftEntry2=b.entry2,b.leftExit0=b.exit0,b.leftExit2=b.exit2):2===c&&(b.rightEntry0=b.entry0,b.rightEntry2=b.entry2,b.rightExit0=b.exit0,b.rightExit2=b.exit2)}Object.defineProperty(m,"__esModule",
{value:!0});n=function(){return function(){this.isCap=this.isLastVertex=this.isFirstVertex=this.closed=void 0;this.currentVertex={x:void 0,y:void 0};this.inbound={x:void 0,y:void 0};this.outbound={x:void 0,y:void 0};this.prevNormal={x:void 0,y:void 0};this.nextNormal={x:void 0,y:void 0};this.bisector={x:void 0,y:void 0};this.leftInner={x:void 0,y:void 0};this.rightInner={x:void 0,y:void 0};this.leftOuter={x:void 0,y:void 0};this.rightOuter={x:void 0,y:void 0}}}();m.TessellationState=n;m.tessellate=
function(c,a,A){d.trackDistance=null!=a.trackDistance?a.trackDistance:!1;d.wrapDistance=null!=a.wrapDistance?a.wrapDistance:65535;d.thin=null!=a.thin?a.thin:!1;d.initialDistance=null!=a.initialDistance?a.initialDistance:0;d.enableOuterBisectorSplit=null!=a.enableOuterBisectorSplit?a.enableOuterBisectorSplit:!1;d.outerBisectorAutoSplitThreshold=null!=a.outerBisectorAutoSplitThreshold?a.outerBisectorAutoSplitThreshold:0;d.enableInnerBisectorSplit=null!=a.enableOuterBisectorSplit?a.enableOuterBisectorSplit:
!1;d.innerBisectorAutoSplitThreshold=null!=a.innerBisectorAutoSplitThreshold?a.innerBisectorAutoSplitThreshold:0;e=c;k=A;l=g=f=0;t=!1;h=r=null;b.currentVertex.x=null;b.currentVertex.y=null;b.distance=d.initialDistance;c=e[0];a=e[e.length-1];b.canSplit=!1;b.closed=c.x===a.x&&c.y===a.y;if(!(2>e.length||2===e.length&&b.closed))if(d.thin)if(d.trackDistance)for(q(),w(),y(1);g-l>d.wrapDistance||f<e.length;)q(),w(),y(2),k.bridge(b),b.leftExit0=b.rightExit0,b.leftExit2=b.rightExit2;else for(;f<e.length;)0<
f&&(b.inbound.x=b.outbound.x,b.inbound.y=b.outbound.y),f<e.length-1?(b.outbound.x=e[f+1].x-e[f].x,b.outbound.y=e[f+1].y-e[f].y,c=Math.sqrt(b.outbound.x*b.outbound.x+b.outbound.y*b.outbound.y),b.distance+=c,b.outbound.x/=c,b.outbound.y/=c):(b.outbound.x=b.inbound.x,b.outbound.y=b.inbound.y),0===f&&(b.inbound.x=b.outbound.x,b.inbound.y=b.outbound.y),b.currentVertex.x=e[f].x,b.currentVertex.y=e[f].y,b.prevNormal.x=-b.inbound.y,b.prevNormal.y=b.inbound.x,b.nextNormal.x=-b.outbound.y,b.nextNormal.y=b.outbound.x,
0===f?(k.vertex(b),b.leftEntry0=b.entry0,b.leftEntry2=b.entry2,b.leftExit0=b.exit0,b.leftExit2=b.exit2):(k.vertex(b),b.rightEntry0=b.entry0,b.rightEntry2=b.entry2,b.rightExit0=b.exit0,b.rightExit2=b.exit2,k.bridge(b),b.leftExit0=b.rightExit0,b.leftExit2=b.rightExit2),++f;else{if(d.enableOuterBisectorSplit||0<d.outerBisectorAutoSplitThreshold||d.enableInnerBisectorSplit||0<d.innerBisectorAutoSplitThreshold)for(b.canSplit=!0,q(),u(),b.splitInner=b.gapInner=b.splitOuter=b.gapOuter=!1,v(1),b.closure0=
b.leftEntry0,b.closure1=b.leftEntry1,b.closure2=b.leftEntry2;g-l>d.wrapDistance||f<e.length-1||f<e.length&&(!b.closed||d.trackDistance);)q(),u(),b.splitInner=b.gapInner=b.splitOuter=b.gapOuter=!1,v(2),k.bridge(b),b.leftExit0=b.rightExit0,b.leftExit1=b.rightExit1,b.leftExit2=b.rightExit2;else for(q(),u(),v(1),b.closure0=b.leftEntry0,b.closure1=b.leftEntry1,b.closure2=b.leftEntry2;g-l>d.wrapDistance||f<e.length-1||f<e.length&&(!b.closed||d.trackDistance);)q(),u(),v(2),k.bridge(b),b.leftExit0=b.rightExit0,
b.leftExit1=b.rightExit1,b.leftExit2=b.rightExit2;b.closed&&!d.trackDistance&&(b.rightEntry0=b.closure0,b.rightEntry1=b.closure1,b.rightEntry2=b.closure2,k.bridge(b),b.leftExit0=b.rightExit0,b.leftExit1=b.rightExit1,b.leftExit2=b.rightExit2)}};m.cleanup=function(){k=e=null};m.splitVertex=x;var e,d={},k,f=void 0,g,l,t,r,h,b=new n;n=function(){function b(a,b){this.writeVertex=a;this.writeTriangle=b;this.capType=p.CapType.BUTT;this.joinType=p.JoinType.MITER;this.miterLimitCosine=z.getLimitCosine(2);
this.roundLimitCosine=Math.cos(23*Math.PI/180);this.almostParallelCosine=.97;this.radsPerSlice=.8;this.joinOnUTurn=this.textured=!1}b.prototype.vertex=function(a){var b=this.joinType===p.JoinType.MITER?this.miterLimitCosine:this.roundLimitCosine,c=a.isCap&&this.capType!==p.CapType.BUTT,d=!1;a.cosine>this.almostParallelCosine?(a.exit0=a.entry0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.bisector.x/a.cosine,a.bisector.y/a.cosine,0,-1,a.distance),a.exit2=a.entry2=this.writeVertex(a.currentVertex.x,
a.currentVertex.y,0,0,-a.bisector.x/a.cosine,-a.bisector.y/a.cosine,0,1,a.distance)):a.cosine<1-this.almostParallelCosine?(d=!a.isCap&&this.joinOnUTurn,a.entry0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.prevNormal.x,a.prevNormal.y,0,-1,a.distance),a.entry2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.prevNormal.x,-a.prevNormal.y,0,1,a.distance),a.exit0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.nextNormal.x,a.nextNormal.y,0,-1,a.distance),a.exit2=this.writeVertex(a.currentVertex.x,
a.currentVertex.y,0,0,-a.nextNormal.x,-a.nextNormal.y,0,1,a.distance)):a.canSplit?(x(),0<a.sign?(a.splitInner?(a.exit0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.outbound.x,a.outbound.y,a.leftInner.x,a.leftInner.y,0,-1,a.distance),a.entry0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.inbound.x,a.inbound.y,a.rightInner.x,a.rightInner.y,0,-1,a.distance)):a.exit0=a.entry0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.inbound.x,a.inbound.y,a.bisector.x/a.cosine,a.bisector.y/
a.cosine,0,-1,a.distance),a.cosine<b?(d=!a.isCap,a.entry2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.prevNormal.x,-a.prevNormal.y,0,1,a.distance),a.exit2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.nextNormal.x,-a.nextNormal.y,0,1,a.distance)):a.splitOuter?(d=d||a.gapOuter,a.entry2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.inbound.x,a.inbound.y,-a.leftOuter.x,-a.leftOuter.y,0,1,a.distance),a.exit2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.outbound.x,
a.outbound.y,-a.rightOuter.x,-a.rightOuter.y,0,1,a.distance)):a.entry2=a.exit2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.bisector.x/a.cosine,-a.bisector.y/a.cosine,0,1,a.distance)):(a.splitInner?(a.exit2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.outbound.x,a.outbound.y,-a.leftInner.x,-a.leftInner.y,0,1,a.distance),a.entry2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.inbound.x,a.inbound.y,-a.rightInner.x,-a.rightInner.y,0,1,a.distance)):a.exit2=a.entry2=this.writeVertex(a.currentVertex.x,
a.currentVertex.y,0,0,-a.bisector.x/a.cosine,-a.bisector.y/a.cosine,0,1,a.distance),a.cosine<b?(d=!a.isCap,a.entry0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.prevNormal.x,a.prevNormal.y,0,-1,a.distance),a.exit0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.nextNormal.x,a.nextNormal.y,0,-1,a.distance)):a.splitOuter?(d=d||a.gapOuter,a.entry0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.inbound.x,a.inbound.y,a.leftOuter.x,a.leftOuter.y,0,-1,a.distance),a.exit0=
this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.outbound.x,a.outbound.y,a.rightOuter.x,a.rightOuter.y,0,-1,a.distance)):a.exit0=a.entry0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.bisector.x/a.cosine,a.bisector.y/a.cosine,0,-1,a.distance))):0<a.sign?(a.exit0=a.entry0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,a.inbound.x,a.inbound.y,a.bisector.x/a.cosine,a.bisector.y/a.cosine,0,-1,a.distance),a.cosine<b?(d=!a.isCap,a.entry2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,
0,0,-a.prevNormal.x,-a.prevNormal.y,0,1,a.distance),a.exit2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.nextNormal.x,-a.nextNormal.y,0,1,a.distance)):a.entry2=a.exit2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.bisector.x/a.cosine,-a.bisector.y/a.cosine,0,1,a.distance)):(a.exit2=a.entry2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.bisector.x/a.cosine,-a.bisector.y/a.cosine,0,1,a.distance),a.cosine<b?(d=!a.isCap,a.entry0=this.writeVertex(a.currentVertex.x,
a.currentVertex.y,0,0,a.prevNormal.x,a.prevNormal.y,0,-1,a.distance),a.exit0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.nextNormal.x,a.nextNormal.y,0,-1,a.distance)):a.exit0=a.entry0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.bisector.x/a.cosine,a.bisector.y/a.cosine,0,-1,a.distance));b=a.canSplit&&(a.splitInner||a.splitOuter)||d||c?a.entry1=a.exit1=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,0,0,0,0,a.distance):a.entry1=a.exit1=null;if(d&&this.joinType!==
p.JoinType.ROUND)this.writeTriangle(b,0<a.sign?a.exit2:a.entry0,0<a.sign?a.entry2:a.exit0);else if(c&&this.capType===p.CapType.ROUND||d&&this.joinType===p.JoinType.ROUND){var e=d=c=void 0,f=void 0,h=void 0,g=void 0;if(a.isCap){var k=Math.PI,h=Math.ceil(k/this.radsPerSlice),g=k/h;a.isFirstVertex?(c=a.prevNormal.x,d=a.prevNormal.y,e=a.entry0,f=a.entry2):a.isLastVertex&&(c=-a.nextNormal.x,d=-a.nextNormal.y,e=a.exit2,f=a.exit0)}else k=2*Math.acos(a.cosine),h=Math.ceil(k/this.radsPerSlice),g=k/h,c=0<a.sign?
-a.prevNormal.x:a.nextNormal.x,d=0<a.sign?-a.prevNormal.y:a.nextNormal.y,e=0<a.sign?a.entry2:a.exit0,f=0<a.sign?a.exit2:a.entry0;for(var k=Math.cos(g),g=Math.sin(g),l=g*c+k*d,c=k*c-g*d,d=l,n,l=void 0,m=0;m<h;++m)n=l,m<h-1&&(l=a.isCap?this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,c,d,a.isFirstVertex?-1:1,0,a.distance):this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,c,d,0,a.sign,a.distance)),this.writeTriangle(0===m?e:n,b,m===h-1?f:l),n=g*c+k*d,c=k*c-g*d,d=n}else c&&this.capType===
p.CapType.SQUARE&&(c=a.isFirstVertex?1:-1,e=d=void 0,this.textured?(d=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.prevNormal.x-c*a.inbound.x,a.prevNormal.y-c*a.inbound.y,-c,-1,a.distance),e=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.prevNormal.x-c*a.inbound.x,-a.prevNormal.y-c*a.inbound.y,-c,1,a.distance)):(d=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.prevNormal.x-c*a.inbound.x,a.prevNormal.y-c*a.inbound.y,0,-1,a.distance),e=this.writeVertex(a.currentVertex.x,
a.currentVertex.y,0,0,-a.prevNormal.x-c*a.inbound.x,-a.prevNormal.y-c*a.inbound.y,0,1,a.distance)),0<c?(this.writeTriangle(b,a.entry2,e),this.writeTriangle(b,e,d),this.writeTriangle(b,d,a.entry0)):(this.writeTriangle(b,e,a.exit2),this.writeTriangle(b,d,e),this.writeTriangle(b,a.exit0,d)))};b.prototype.bridge=function(a){this.writeTriangle(a.leftExit0,a.rightEntry0,null!=a.leftExit1?a.leftExit1:a.leftExit2);this.writeTriangle(a.rightEntry0,null!=a.rightEntry1?a.rightEntry1:a.rightEntry2,null!=a.leftExit1?
a.leftExit1:a.leftExit2);null!=a.leftExit1&&null!=a.rightEntry1?(this.writeTriangle(a.leftExit1,a.rightEntry1,a.leftExit2),this.writeTriangle(a.rightEntry1,a.rightEntry2,a.leftExit2)):null!=a.leftExit1?this.writeTriangle(a.leftExit1,a.rightEntry2,a.leftExit2):null!=a.rightEntry1&&this.writeTriangle(a.rightEntry1,a.rightEntry2,a.leftExit2)};return b}();m.StandardTessellationCallbacks=n;n=function(){function b(a,b){this.writeVertex=a;this.writeTriangle=b}b.prototype.vertex=function(a){a.entry0=this.writeVertex(a.currentVertex.x,
a.currentVertex.y,0,0,a.prevNormal.x,a.prevNormal.y,0,-1,a.distance);a.entry2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.prevNormal.x,-a.prevNormal.y,0,1,a.distance);a.exit0=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,a.nextNormal.x,a.nextNormal.y,0,-1,a.distance);a.exit2=this.writeVertex(a.currentVertex.x,a.currentVertex.y,0,0,-a.nextNormal.x,-a.nextNormal.y,0,1,a.distance)};b.prototype.bridge=function(a){this.writeTriangle(a.leftExit0,a.rightEntry0,a.leftExit2);this.writeTriangle(a.rightEntry0,
a.rightEntry2,a.leftExit2)};return b}();m.ThinTessellationCallbacks=n});