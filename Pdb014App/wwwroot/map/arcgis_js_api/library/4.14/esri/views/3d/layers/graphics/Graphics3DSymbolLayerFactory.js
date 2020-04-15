// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/Logger ./Graphics3DExtrudeSymbolLayer ./Graphics3DIconSymbolLayer ./Graphics3DLineSymbolLayer ./Graphics3DMeshFillSymbolLayer ./Graphics3DObjectSymbolLayer ./Graphics3DPathSymbolLayer ./Graphics3DPolygonFillSymbolLayer ./Graphics3DTextSymbolLayer ./Graphics3DWaterSymbolLayer".split(" "),function(v,a,c,h,k,l,m,n,p,q,r,t){Object.defineProperty(a,"__esModule",{value:!0});var u=c.getLogger("esri.views.3d.layers.graphics.Graphics3DSymbolLayerFactory");a.make=function(d,
b,a,c){var g=e[d.type]&&e[d.type][b.type]||f[b.type];return g?new g(d,b,a,c):(u.error("GraphicsLayerFactory#make","unknown symbol type "+b.type),null)};var f={icon:k.default,object:n.default,line:l.default,path:p.default,fill:q.default,extrude:h.default,text:r.default,water:t.default};a.setSymbolClass=function(a,b){f[a]=b};var e={"mesh-3d":{fill:m.default}}});