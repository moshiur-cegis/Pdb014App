// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See https://js.arcgis.com/4.14/esri/copyright.txt for details.
//>>built
define("require exports ../../../../core/maybe ../../../../core/libs/gl-matrix-2/mat4 ../../../../core/libs/gl-matrix-2/mat4f64 ../../../../core/libs/gl-matrix-2/vec3f64 ../../../../core/libs/gl-matrix-2/vec4f64 ../../../../support/elevationInfoUtils ../../../../support/featureFlags ../Manipulator3D ../manipulatorUtils ../dragUtils/dragAtLocation ../dragUtils/projectScreenToMap ../../webgl-engine/lib/Geometry ../../webgl-engine/lib/GeometryUtil ../../webgl-engine/materials/NativeLineMaterial ../../webgl-engine/materials/RibbonLineMaterial ../../../interactive/GraphicManipulator ../../../interactive/dragUtils/screenDragToMap".split(" "),
function(E,c,e,f,q,g,w,x,y,z,r,A,m,t,u,B,C,D,h){function v(a,b){return"on-the-ground"===b.mode||e.isNone(a.geometry)||!a.geometry.hasZ?!1:!0}Object.defineProperty(c,"__esModule",{value:!0});c.createGraphicMoveXYManipulator=function(a,b){return new D.GraphicManipulator({graphic:b,view:a,selectable:!0,cursor:"move"})};c.createGraphicMoveXYScreenDragToMap=function(a,b,c){return h.createXYConstrainedFromProject(m.createForGraphic(a,b.graphic,c.start),e.expect(b.graphic.geometry).spatialReference)};c.canMoveZ=
v;c.createGraphicMoveZManipulator=function(a){var b=a.graphic,c=a.view;if(!y.enableEditing3D())return null;var e=x.getGraphicEffectiveElevationInfo(b);if(!v(b,e))return null;var n=[g.vec3f64.fromValues(0,0,0),g.vec3f64.fromValues(0,0,90)],n=new t(u.createPolylineGeometry(n),"move-z"),p=u.createConeGeometry(20,5,16,!1),p=new t(p),m=[g.vec3f64.fromValues(0,0,0),g.vec3f64.fromValues(0,0,110)],k=q.mat4f64.create();f.mat4.translate(k,k,[0,0,90]);f.mat4.rotateX(k,k,Math.PI/2);var d=q.mat4f64.create();f.mat4.translate(d,
d,[0,0,90]);f.mat4.rotateX(d,d,Math.PI/2);f.mat4.scale(d,d,[1.2,1.2,1]);var l=g.vec3f64.fromValues(0,.5,.9),h=w.vec4f64.fromValues(l[0],l[1],l[2],1);return new z.Manipulator3D({view:c,renderObjects:[{geometry:n,material:function(){var a=new B({color:h},"move-z");a.renderOccluded=4;return a}(),stateMask:1},{geometry:p,transform:k,material:r.createManipulatorMaterial(l,1),stateMask:1},{geometry:n,material:function(a){a=new C({color:h,width:a},"move-z");a.renderOccluded=4;return a}(2),stateMask:2},{geometry:p,
transform:d,material:r.createManipulatorMaterial(l,1),stateMask:2}],collisionType:{type:"line",paths:[m]},autoScaleRenderObjects:!1,worldSized:!1,radius:4,selectable:!1,cursor:"ns-resize",elevationInfo:e,worldOriented:null!=a.worldOriented?a.worldOriented:!0,visible:!!b.visible})};c.createGraphicMoveZScreenDragToMap=function(a,b){var c=h.createZConstrainedFromProject(m.createCameraAlignedWorldUp(a,b.elevationAlignedLocation),b.location.spatialReference);return A.dragAtLocation(a,c,b.elevationAlignedLocation)}});