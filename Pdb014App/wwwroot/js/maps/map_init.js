
//map.createPane('pane-llp').style.zIndex = 610;
//map.createPane('pane-llp').style.zIndex = 610;
//var markersB = createMarkerClusterGroup('myclusterB', 'paneB');

//function onmove() {
//    // Get the map bounds - the top-left and bottom-right locations.
//    var inBounds = [],
//        bounds = map.getBounds();
//    markers.eachLayer(function (marker) {
//        // For each marker, consider whether it is currently visible by comparing
//        // with the current map bounds.
//        if (bounds.contains(marker.getLatLng())) {
//            inBounds.push(marker.options.title);
//        }
//    });
//    // Display a list of markers.
//    document.getElementById('coordinates').innerHTML = inBounds.join('\n');
//}

var map,
    zooming = 7,
    adminCode,
    data_type = 1,
    map_data = [],
    other_data = [],
    data_info = [],
    //baseUrl = "@Url.Action("Index", "SurveyInfoes")",
    noDataClass = "#FFFFFF",
    legendTheme,
    dataLayer = null,
    otherLayer = null,
    mapLabels = new L.LayerGroup(),
    otherLabels = new L.LayerGroup(),
    adminLayers = {},
    otherLayers = {},
    equipmentClusters = {},
    equipmentTypes = {
        "1": "Low Lift Pump (LLP)",
        "2": "Deep Tubewell (DTW)",
        "3": "Shallow Tubewell (STW)"
    },
    //adminMapLabels = new L.LayerGroup(),
    polyDefaultOptions = {
        zIndex: 101,
        weight: 1.0,
        opacity: 0.9,
        color: "#D0C0A0",
        fillOpacity: 0.8
    };



$(function () {

    adminCode = "dist";
    $("#admin_info").val(adminCode);
    $("#map_label_opt").prop("checked", false);

    set_basic_opts();

    set_survey_data();

    draggable_modal("option_title", "map_filter_content", "map_filter_bg", false);

});


function set_basic_opts() {

    if (typeof (L) == "undefined" || L == undefined) {
        legend_open_close("legend", "close", "right");
        $("#legend").css("right", "-1000px");
        legend_open_close("legend_info", "close", "left");
        $("#legend_info").css("left", "-1000px");

        msg.init("error", "Error... . .", "Map Loading Failed !");
        $("#busy-indicator").fadeOut();

        return false;
    }

    //drawnItems = new L.FeatureGroup();
    //Google Map
    //Hybrid: s,h;
    //Satellite: s;
    //Streets: m;
    //Terrain: p;

    var blankUrl = "../images/blank.png",
        osmUrl = "http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
        baseUrl = "https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoiYWxoYWRpLWNzZSIsImEiOiJjamx1azJ5emcwamlkM3ZxeHB0ajB0d3I1In0.k_DovXLLPpp7fQ_i685ocA",
        googleUrl = "http://{s}.google.com/vt/lyrs=p&x={x}&y={y}&z={z}",
        esriUrl = "http://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}",
        mapAttrib = "Map data © <a href='https://www.cegisbd.com/' target='_blank'>CEGIS</a> & <a href='http://badc.gov.bd/' target='_blank'>BADC</a>";

    var blank = L.tileLayer(blankUrl, { minZoom: 0, maxZoom: 25, attribution: mapAttrib }),
        openstreet = L.tileLayer(osmUrl, { minZoom: 0, maxZoom: 25, attribution: mapAttrib }),
        grayscale = L.tileLayer(baseUrl, { minZoom: 0, maxZoom: 25, id: "mapbox.light", attribution: mapAttrib }),
        streets = L.tileLayer(baseUrl, { minZoom: 0, maxZoom: 25, id: "mapbox.streets", attribution: mapAttrib }),
        google = L.tileLayer(googleUrl, { minZoom: 0, maxZoom: 25, subdomains: ["mt0", "mt1", "mt2", "mt3"], attribution: mapAttrib }),
        esri = L.tileLayer(esriUrl, { minZoom: 0, maxZoom: 25, attribution: mapAttrib });


    //L.mapbox.accessToken = "pk.eyJ1IjoiYWxoYWRpLWNzZSIsImEiOiJjamx1azJ5emcwamlkM3ZxeHB0ajB0d3I1In0.k_DovXLLPpp7fQ_i685ocA";

    //map = new L.Map("map").setView([23.737777, 90.537777], 7);preferCanvas: true, 

    map = new L.Map("map", { center: new L.LatLng(23.737777, 90.537777), zoomControl: false, zoom: 7.0 });
    map.setView([23.737777, 90.537777], 7.0);

    var baseMaps = {
        "None": blank,
        "Open Street": openstreet,
        "Grayscale": grayscale,
        "Streets": streets,
        "Google": google,
        "ESRI": esri
    };


    //map.createPane("data-layer").style.zIndex = 401;
    map.createPane("other-layer").style.zIndex = 403;
    map.createPane("admin-layer").style.zIndex = 405;

    //map.createPane("marker-layer").style.zIndex = 600;
    map.createPane("label-layer").style.zIndex = 601;

    //map.createPane("admin").style.zIndex = 455;

    //drawnItems.addTo(map);
    //drawnItems.addTo(map);

    L.tileLayer("", { attribution: mapAttrib }).addTo(map);
    //L.control.layers(baseMaps, { "Select Layer": drawnItems }, { position: "topright", collapsed: true }).addTo(map);

    L.control.scale().addTo(map);
    //L.control.pan().addTo(map);
    L.control.zoom().addTo(map);

    map.on("mousemove",
        function (evt) {
            $("#map_cord_info").html(evt.latlng.lat.toFixed(6) + ", " + evt.latlng.lng.toFixed(6));
        });

    $("#map_center").on("click",
        function (e) {
            map.setView([23.737777, 90.537777], 7.0);
        });

    //L.control.layers(null, baseMaps, { collapsed: false }).addTo(map);
    var bglayers = L.control.layers(baseMaps, null, { collapsed: false });

    bglayers.addTo(map);
    //$("#bglayers_content").append(bglayers.getContainer());

    var bglayers_content = $(bglayers.getContainer());
    bglayers_content.find("a.leaflet-control-layers-toggle").remove();
    bglayers_content.find("form.leaflet-control-layers-list").css("display", "block");
    $("#map_bglayers").append(bglayers_content);


    $("#map_label_opt").on("change",
        function () {
            map_label_show_hide(this.checked);
        });

    $("#map_full_screen").on("click",
        function () {
            if (!confirm("Are you sure to close full screen ?"))
                return;

            $("#map_info").toggleClass("map-full-screen");
        });

    $("input[type='checkbox'].multi-chkbx.admin").each(function () {
        $(this).on("change",
            function () {
                if (!$(this).prop("id").replace("admin_", ""))
                    return;

                var adminCode = $(this).prop("id").replace("admin_", "");

                $("#busy-indicator").fadeIn();

                if (this.checked)
                    add_admin_boundary(adminCode);
                else
                    remove_admin_boundary(adminCode);

                $("#busy-indicator").fadeOut();
            });
    });

    $("input[type='checkbox'].multi-chkbx.other_layer").each(function () {
        $(this).on("change",
            function () {
                if (!$(this).prop("id"))
                    return;

                var layerCode = $(this).prop("id"),
                    dataCode = $(this).attr("data");

                $("#busy-indicator").fadeIn();

                if (this.checked)
                    add_other_layer(layerCode, dataCode);
                else
                    remove_other_layer(layerCode);

                $("#busy-indicator").fadeOut();
            });
    });

    $("input[type='checkbox'].multi-chkbx.admin-label").each(function () {
        $(this).on("change",
            function () {
                if (!$(this).prop("id").replace("admin_label_", ""))
                    return;

                var adminCode = $(this).prop("id").replace("admin_label_", "");

                $("#busy-indicator").fadeIn();

                add_remove_admin_label(adminCode, this.checked);

                $("#busy-indicator").fadeOut();
            });
    });

    $("#admin_info").on("change",
        function () {
            set_survey_data();
            return false;
        });

    $("#survey_info").on("change",
        function () {
            //map_selected_info();

            if ($("#survey_info").val() != 0) {
                set_survey_data();
            }
        });

    $("#legend_theme").on("change",
        function () {
            set_survey_data();
        });

    //$("#legend_theme").on("change", function () {
    //    map_init($("#admin_info").val());
    //});

    $("#legend_info_opt").change(function () {
        if (this.checked) {
            legend_open_close("legend_info", "open", "left");
        } else {
            legend_open_close("legend_info", "close", "left");
        }
        return false;
    });

    $("#legend_opt").change(function () {
        if (this.checked) {
            legend_open_close("legend", "open", "right");
        } else {
            legend_open_close("legend", "close", "right");
        }
        return false;
    });


    $("#basic_survey").on("change",
        function () {

            if (!dataLayer) {
                add_data_layer();
                return;
            }

            if (this.checked) {
                if (!map.hasLayer(dataLayer))
                    map.addLayer(dataLayer);

                $("#admin_sban").prop("checked", true);
                //add_admin_boundary("sban");

                $("input[type='checkbox'].multi-chkbx.admin").each(function () {
                    if (this.checked) {
                        add_admin_boundary($(this).prop("id").replace("admin_", ""));
                    }
                });

                $("input[type='checkbox'].multi-chkbx.other_layer").each(function () {
                    if (this.checked) {
                        add_other_layer($(this).prop("id"), $(this).attr("data"));
                    }
                });

                map_label_show_hide($("#map_label_opt").prop("checked"));

                $("#map_legend_basic_data").slideDown(350);
                //$("#map_legend_basic_data").css("display", "");

                $("#legend_info_opt").prop("checked", true).trigger("change");
            } else {
                if (map.hasLayer(dataLayer))
                    map.removeLayer(dataLayer);

                $("#admin_sban").prop("checked", false);
                remove_admin_boundary("sban");

                map_label_show_hide(false);

                $("#map_legend_basic_data").slideUp(350);
                //$("#map_legend_basic_data").css("display", "none");

                $("#legend_info_opt").prop("checked", false).trigger("change");
            }
        });


    //{
    //    "equipment_type": "Low Lift Pump (LLP)",
    //        "address": "NSS, Pallabi Residential Area, Haji Bari Mosjid",
    //        "road_or_village": "Pallabi Residential Area",
    //        "mobile_no": "01712-795359",
    //        "image_name": "680_1.jpg",
    //        "lat": 22.1380571,
    //        "long": 90.2302515,
    //        "district_code": 1004,
    //        "upazila_code": 100409,
    //        "union_code": 10040902,
    //        "mauza_code": 10040903400,
    //        "district_name": "Barguna",
    //        "upazila_name": "Amtali",
    //        "union_name": "Ward No-02",
    //        "mauza_name": "Kontakata(Dakshin)"
    //}


    //var markerClusters = new L.MarkerClusterGroup({
    //    maxClusterRadius: 125,
    //    //iconCreateFunction: function (cluster) {
    //    //    var markers = cluster.getAllChildMarkers();
    //    //    var n = 0;
    //    //    for (var i = 0; i < markers.length; i++) {
    //    //        n += markers[i].number;
    //    //    }
    //    //    return L.divIcon({ html: n, className: "mycluster", iconSize: L.point(40, 40) });
    //    //},
    //    ////Disable all of the defaults:
    //    //spiderfyOnMaxZoom: false, showCoverageOnHover: false, zoomToBoundsOnClick: false
    //});

    //var eqp_loc = null;



    //map.createPane("pane1").style.zIndex = 610;

    $("#eqp_loc").on("change",
        function () {

            if (this.checked) {

                //if (eqp_loc == null || eqp_loc.length < 1) {}

                try {

                    $.getJSON("../js/maps/map_data/locations.json",
                        function (allLocations) {

                            if (allLocations.locations && allLocations.locations.length > 0) {

                                var icon = {
                                    pane: "label-layer",
                                    radius: 6,
                                    color: "blue",
                                    weight: 2.5,
                                    opacity: 0.6,
                                    fillColor: "red",
                                    fillOpacity: 0.8
                                };

                                equipmentClusters = {
                                    "1": new L.MarkerClusterGroup({
                                        //pane: "marker-layer",
                                        maxClusterRadius: 100,
                                        iconCreateFunction: function (cluster) {
                                            var markers = cluster.getAllChildMarkers();
                                            return L.divIcon({
                                                html: "<div>" + markers.length + "</div>",
                                                className: "marker-cluster-eqp cluster-llp",
                                                iconSize: L.point(35, 35)
                                            });
                                        },
                                        //clusterPane: "pane1",

                                        spiderLegPolylineOptions: { weight: 0 },
                                        clockHelpingCircleOptions: {
                                            weight: .7,
                                            opacity: 1,
                                            color: 'black',
                                            fillOpacity: 0,
                                            dashArray: '10 5'
                                        },

                                        elementsPlacementStrategy: "original-locations",
                                        helpingCircles: true,

                                        spiderfyDistanceSurplus: 25,
                                        spiderfyDistanceMultiplier: 1,

                                        elementsMultiplier: 1.4,
                                        firstCircleElements: 8
                                    }),
                                    /*equipmentClusters[2] =*/
                                    "2": new L.MarkerClusterGroup({
                                        //pane: "marker-layer",
                                        maxClusterRadius: 100,
                                        iconCreateFunction: function (cluster) {
                                            var markers = cluster.getAllChildMarkers();
                                            return L.divIcon({
                                                pane: "label-layer",
                                                html: "<div>" + markers.length + "</div>",
                                                className: "marker-cluster-eqp cluster-dtw",
                                                iconSize: L.point(35, 35)
                                            });
                                        }
                                    }),
                                    /*equipmentClusters[3] =*/
                                    "3": new L.MarkerClusterGroup({
                                        //pane: "marker-layer",
                                        maxClusterRadius: 100,
                                        iconCreateFunction: function (cluster) {
                                            var markers = cluster.getAllChildMarkers();
                                            return L.divIcon({
                                                pane: "label-layer",
                                                html: "<div>" + markers.length + "</div>",
                                                className: "marker-cluster-eqp cluster-stw",
                                                iconSize: L.point(35, 35)
                                            });
                                        }
                                    })
                                };


                                var getLatLng = function (lat, lng) {
                                    return new L.LatLng(lat, lng);
                                },
                                    getInfo = function (el) {
                                        return (el == "undefined")
                                            ? ""
                                            : "<div style='display: inline-block; overflow: auto; max-height: 654px; max-width: 654px;'>" +
                                            "    <table>" +
                                            "        <tr>" +
                                            "            <td colspan='2'>" +
                                            "                <h3><b>Equipment:</b> <span style='color: #05c;'>" +
                                            equipmentTypes[el.equipment_type] +
                                            "</span></h3>" +
                                            "            </td>" +
                                            "        </tr>" +
                                            "        <tr>" +
                                            "            <td style='width: 100%; vertical-align: top;'>" +
                                            "                <div  style='min-width:175px;'>" +
                                            "<h4><b>Mauza:</b> " +
                                            el.mauza_name +
                                            "</h4><h4><b>Union:</b> " +
                                            el.union_name +
                                            "</h4><h4><b>Upazila:</b> " +
                                            el.upazila_name +
                                            "</h4><h4><b>District:</b> " +
                                            el.district_name +
                                            //"</h4><h4><b>Address:</b> " + el.address + "</h4>"
                                            "</h4><h4><b>Latitude:</b> " +
                                            el.lat +
                                            ", <b>Longitude:</b> " +
                                            el.long +
                                            "</h4>" +
                                            "                </div>" +
                                            "            </td>" +
                                            "            <td style='width: auto; vertical-align: top;'>" +
                                            "                <div style='height: 250px; padding: 0;'>" +
                                            "                    <img style='border: 0 none; width: auto; max-height: 240px; margin: 0; padding: 0;' src='../images/badc_home/badc_" +
                                            (Math.floor(Math.random() * 10) + 1) +
                                            ".png'>" +
                                            "                </div>" +
                                            "            </td>" +
                                            "        </tr>" +
                                            "    </table>" +
                                            "</div>";
                                    };


                                //var tc = 0;

                                allLocations.locations.forEach(function (el, i) {

                                    var location = new L.CircleMarker(getLatLng(el.lat, el.long), icon)
                                        .bindPopup(getInfo(el, i))
                                        .on({
                                            "mouseover": function (e) {
                                                this.setStyle({
                                                    weight: 2.5,
                                                    opacity: 0.8
                                                });
                                            },
                                            "mouseout": function (e) {
                                                //e.target.resetStyle();

                                                this.setStyle({
                                                    weight: 2.0,
                                                    opacity: 0.6
                                                });
                                            }
                                        });

                                    switch (el.equipment_type) {
                                        case "1":
                                            {
                                                icon.color = "blue";
                                                icon.fillColor = "red";

                                                location.icon = icon;
                                                equipmentClusters[1].addLayer(location);
                                            }
                                            break;

                                        case "2":
                                            {
                                                icon.color = "red";
                                                icon.fillColor = "green";

                                                location.icon = icon;
                                                equipmentClusters[2].addLayer(location);
                                            }
                                            break;

                                        case "3":
                                            {
                                                icon.color = "green";
                                                icon.fillColor = "blue";

                                                location.icon = icon;
                                                equipmentClusters[3].addLayer(location);
                                            }
                                            break;

                                        default:
                                            break;
                                    }

                                });

                                //console.log(tc);
                                //map.addLayer(markerClusters);
                                //map.addLayer(locations);
                                //console.log(markerClusters);

                                //map.addLayer(equipmentClusters);
                                map.addLayer(equipmentClusters[1]);
                                map.addLayer(equipmentClusters[2]);
                                map.addLayer(equipmentClusters[3]);


                                $("#map_legend_colors").append(
                                    "<div id='map_legend_loc_1'><label class='map_legend_label'>" +
                                    "<label class='map_legend_color map_legend_circle' style='border-color:#34e; background-color:#e32;'></label>" +
                                    equipmentTypes[1] +
                                    "</label> <br /><div>");

                                $("#map_legend_colors").append(
                                    "<div id='map_legend_loc_2'><label class='map_legend_label'>" +
                                    "<label class='map_legend_color map_legend_circle' style='border-color:#e43; background-color:#3e2;'></label>" +
                                    equipmentTypes[2] +
                                    "</label> <br /><div>");

                                $("#map_legend_colors").append(
                                    "<div id='map_legend_loc_3'><label class='map_legend_label'>" +
                                    "<label class='map_legend_color map_legend_circle' style='border-color:#1e1; background-color:#23e;'></label>" +
                                    equipmentTypes[3] +
                                    "</label> <br /><div>");

                                $("#eqp_types").slideDown(350);
                                $("#eqp_types").find("input[type='checkbox']").each(function () {
                                    $(this).prop("checked", true);
                                    $(this).prop("disabled", false);

                                    $(this).on("change",
                                        function () {

                                            if ($("#eqp_types").find("input[type='checkbox']").length === $("#eqp_types").find("input[type='checkbox']:checked").length) {
                                                $("#eqp_loc").prop("indeterminate", false);
                                                $("#eqp_loc").prop("checked", true);
                                            } else if ($("#eqp_types").find("input[type='checkbox']:checked").length > 0) {
                                                $("#eqp_loc").prop("indeterminate", true);
                                                $("#eqp_loc").prop("checked", false);
                                            } else {
                                                $("#eqp_loc").prop("indeterminate", false);
                                                $("#eqp_loc").prop("checked", false);
                                            }


                                            if (!$(this).prop("id").replace("eqp_", "") || !equipmentClusters)
                                                return;

                                            var eqpId = $(this).prop("id").replace("eqp_", "");

                                            if (!equipmentClusters[eqpId])
                                                return;

                                            if (this.checked) {
                                                if (!map.hasLayer(equipmentClusters[eqpId]))
                                                    map.addLayer(equipmentClusters[eqpId]);

                                                if ($("#map_legend_loc_" + eqpId))
                                                    $("#map_legend_loc_" + eqpId).show();
                                            } else {
                                                if (map.hasLayer(equipmentClusters[eqpId]))
                                                    map.removeLayer(equipmentClusters[eqpId]);

                                                if ($("#map_legend_loc_" + eqpId))
                                                    $("#map_legend_loc_" + eqpId).hide();
                                            }
                                        });

                                    //($(this).prop("id").replace("eqp_", ""));

                                    //if (this.checked) {
                                    //    add_admin_boundary($(this).prop("id").replace("admin_", ""));
                                    //}
                                });
                            }
                        });

                } catch (e) {
                    msg.init("Error", "Error... . .", "Error trying to load/parse JSON data !! <br />" + e.message);
                }

            } else {
                for (var ei = 1; ei <= 3; ei++) {
                    if (map.hasLayer(equipmentClusters[ei]))
                        map.removeLayer(equipmentClusters[ei]);

                    if ($("#map_legend_loc_" + ei))
                        $("#map_legend_loc_" + ei).remove();
                }

                equipmentClusters = {};

                $("#eqp_types").find("input[type='checkbox']").each(function () {
                    $(this).prop("checked", false);
                    $(this).prop("disabled", true);
                });

                $("#eqp_types").slideUp(350);

            }
        });


    tt();

    return true;
}


//if ($("#basic_survey").prop("checked")) {
//    add_data_layer();
//} else {
//    adminCode = "union";

//    $("#admin_div").prop({ "checked": false, "disabled": false });
//    $("#admin_dist").prop({ "checked": false, "disabled": false });
//    $("#admin_upaz").prop({ "checked": false, "disabled": false });
//    $("#admin_union").prop({ "checked": false, "disabled": false });
//}



function set_survey_data() {

    var adminCode = $("#admin_info").val(),
        dataCode = $("#survey_info").val();

    map_data = [];
    try {
        $.getJSON("../js/maps/map_data/" + "all_data" + ".json", function (allData) {
            if (allData && allData.all_data.length > 0) {
                //console.log(allData.all_data);

                allData.all_data.some(function (ad, i) {
                    if (ad.adminCode == adminCode) {
                        map_data = ad.data.map(function (d, i) {
                            return { geo_code: d[adminCode + "Code"], data_value: d[dataCode] };
                        });
                        return true;
                    }
                    return false;
                });

                //add_data_layer();
            }
        }).done(function (e) {
            add_data_layer();
        });

    } catch (e) {
        map_data = [];
        msg.init("Error", "Error... . .", "Error trying to load/parse JSON data !! <br />" + e.message);
    }

}


//$("input[type='checkbox'].multi-chkbx.layer").each(function () {
//    if (this.checked && $(this).prop("id")) {
//        add_other_data_layer($(this).prop("id"), $(this).attr("data"));
//    }
//});


var isOpened = false;

function map_filter_open_close(content, isOpen) {
    if (isOpened === isOpen) return;

    if (isOpen && !isOpened)
        modal_open(content, 50);
    else if (!isOpen && isOpened)
        modal_close(content);

    isOpened = isOpen;
}

function legend_open_close(legendId, openCloseOpt, propOpt) {
    if (openCloseOpt == "open") {
        $("#" + legendId + "_btn")
            .css(propOpt, "-" + ($("#" + legendId + "_btn").outerWidth(true) + 10) + "px");
        $("#" + legendId).css(propOpt, "-2px");

        $("#" + legendId + "_opt").prop("checked", true);
    } else if (openCloseOpt == "close") {
        $("#" + legendId).css(propOpt, "-" + ($("#" + legendId).outerWidth(true) + 5) + "px");
        $("#" + legendId + "_btn").css(propOpt, "-10px");

        $("#" + legendId + "_opt").prop("checked", false);
    }
}

function get_unique_theme(mapData) {

    if (!mapData || mapData.length < 1) return [];

    var theme = [], tc = 0;

    var unique_data = mapData.filter(function (itm, i, mapData) {
        return i == mapData.indexOf(itm);
    });

    unique_data.map(function (md, c) {
        if (typeof md == "undefined")
            return;

        theme[tc] = {
            val: md,
            title: md,
            color: "#" + ("00000" + (Math.floor(0xFFFFFF * Math.random()) << 0).toString(16)).slice(-6).toUpperCase()
        };
        //theme[tc] = { val: md, title: md, color: random_color("hex") };
        ++tc;
    });

    theme[tc] = { val: "", title: "-", color: "#FFFFFF" };

    return theme;
}

function random_color(format) {
    var ran_int = Math.floor(0x100000000 * Math.random());
    switch (format) {
        case "hex":
            return "#" + ("00000" + ran_int.toString(16)).slice(-6).toUpperCase();
        case "hexa":
            return "#" + ("0000000" + ran_int.toString(16)).slice(-8).toUpperCase();
        case "rgb":
            return "rgb(" + (ran_int & 255) + "," + (ran_int >> 8 & 255) + "," + (ran_int >> 16 & 255) + ")";
        case "rgba":
            return "rgba(" + (ran_int & 255) + "," + (ran_int >> 8 & 255) + "," + (ran_int >> 16 & 255) + "," + (ran_int >> 24 & 255) / 255 + ")";
        default:
            return ran_int;
    }
}


function get_dynamic_theme(mapData) {
    var minVal = Infinity, maxVal = -Infinity, currVal, theme = [];

    if (!mapData || mapData.length < 1)
        mapData = map_data;

    if (!mapData || mapData.length < 1) return theme;

    for (var dc = 0; dc < mapData.length; dc++) {
        if (!mapData[dc].data_value)
            continue;


        //if (!currVal && currVal != 0) $.isNumeric(mapData[dc].data_value)
        if (isNaN(parseFloat(mapData[dc].data_value)))
            continue;

        currVal = parseFloat(mapData[dc].data_value);

        if (minVal > currVal)
            minVal = currVal;
        if (maxVal < currVal)
            maxVal = currVal;
    }


    //var clrClass = ["#FFEEDD", "#FEBBAA", "#FE9988", "#FA7766", "#FA5544", "#FA3322", "#FA1100"],
    var clrClass = ["#FFFF80", "#FAD155", "#F2A82F", "#AD5314", "#6A0000", "#4A0000"],
        delta = parseInt((maxVal - minVal) / clrClass.length),
        ci = 0;

    for (ci = 0; ci < clrClass.length; ci++) {
        if (ci === 0) {
            theme[ci] = { minVal: minVal, maxVal: delta, color: clrClass[ci] };
        } else if (ci === clrClass.length - 1) {
            theme[ci] = { minVal: (delta * ci) + 1, maxVal: maxVal, color: clrClass[ci] };
        } else {
            theme[ci] = { minVal: (delta * ci) + 1, maxVal: (delta * (ci + 1)), color: clrClass[ci] };
        }
    }

    theme[ci] = { minVal: "noData", maxVal: "-", color: "#FFFFFF" };

    return theme;
}

function get_theme(minVal, maxVal) {
    var theme = [];

    if (!minVal || !maxVal) return theme;

    //var clrClass = ["#FFEEDD", "#FEBBAA", "#FE9988", "#FA7766", "#FA5544", "#FA3322", "#FA1100"],
    var clrClass = ["#AFFF80", "#AAD155", "#A2A82F", "#8D5314", "#5A0000", "#3A0000"],
        delta = parseInt((maxVal - minVal) / clrClass.length),
        ci;

    for (ci = 0; ci < clrClass.length; ci++) {
        if (ci === 0) {
            theme[ci] = { minVal: minVal, maxVal: delta, color: clrClass[ci] };
        } else if (ci === clrClass.length - 1) {
            theme[ci] = { minVal: (delta * ci) + 1, maxVal: maxVal, color: clrClass[ci] };
        } else {
            theme[ci] = { minVal: (delta * ci) + 1, maxVal: (delta * (ci + 1)), color: clrClass[ci] };
        }
    }

    theme[ci] = { minVal: "noData", maxVal: "-", color: "#FFFFFF" };

    return theme;
}


function map_label_show_hide(isShow) {
    if (!mapLabels)
        return;

    $("#map_label_opt").prop("checked", isShow);

    if (isShow) {
        if (!map.hasLayer(mapLabels))
            map.addLayer(mapLabels);
        //$(".map_label").fadeIn(500);
    } else {
        if (map.hasLayer(mapLabels))
            map.removeLayer(mapLabels);
        //$(".map_label").fadeOut(500);
    }

    return;
}




function add_data_layer() {

    $("#legend_title").empty();
    $("#legend_info_title").empty();
    $("#map_legend_infos").empty();
    $("#map_legend_colors").empty();

    adminCode = $("#admin_info").val();

    if (!adminCode || !map)
        return;

    if (dataLayer) {
        if (map.hasLayer(dataLayer))
            map.removeLayer(dataLayer);
        dataLayer = null;
    }

    if (mapLabels) {
        if (map.hasLayer(mapLabels))
            map.removeLayer(mapLabels);
        mapLabels = new L.LayerGroup();

        $("#map_label_opt").prop("checked", false);
    }

    $(".map_label").remove();

    var dataLayerPath = "../js/maps/map_data/" + adminCode + ".json";

    var //adminFieldCode = adminCode + "_code",
        //adminFieldName = adminCode + "_name",
        adminName = $("#admin_info option:selected").text(),
        dataName = $("#survey_info option:selected").text(),
        totalValue = 0,
        table = $("<table>").addClass("table");


    legendTheme = $("#legend_theme").val() == "dynamic"
        ? get_dynamic_theme(map_data)
        : legend_themes[adminCode + "_" + $("#survey_info").val()];

    if (!legendTheme) {
        legendTheme = get_dynamic_theme(map_data);
        $("#legend_theme").val("dynamic");
    }

    if (legendTheme && legendTheme.length > 0) {
        noDataClass = legendTheme[legendTheme.length - 1].color;
        legendTheme.splice(-1, 1);
    }

    map_data.map(d => totalValue += parseFloat(d.data_value));
    totalValue = (totalValue % 1 == 0) ? totalValue : totalValue.toFixed(2);


    $("#legend_title").append(dataName + " legend ");
    $("#legend_info_title").append(adminName + " Wise " + dataName + " (" + totalValue + ")");

    $("#map_legend_infos").append(table);
    table.append("<tr><th>" + adminName + "</th> <th>" + dataName + "</th></tr>");


    //L.geoJson(dataLayerPath, {
    //    style: function (feature) {
    //        return { color: feature.properties.color };
    //    }
    //}).bindPopup(function (layer) {
    //    return layer.feature.properties.description;
    //}).addTo(map);

    $.getJSON(dataLayerPath, function (map_layer) {
        if (!map_layer) return;

        mapLabels = new L.LayerGroup();

        dataLayer = L.geoJson(map_layer, { style: mapDataStyle, onEachFeature: mapDataFeatures });

    }).done(function (e) {

        $("#basic_survey").prop("checked", true);
        map.addLayer(dataLayer);

        table.append(
            "<tr><td style='padding-right:8px; text-align:right; font-weight:600;'> Total: </td> <td style='padding-right:8px; text-align:right; font-weight:600;'> " +
            totalValue +
            "</td></tr>");

        var $legend_div = $("<div id='map_legend_basic_data'></div>");
        if (legendTheme && legendTheme.length > 0) {

            legendTheme.map(function (d, i) {

                var legend;
                if (d.minVal && !parseFloat(d.minVal)) {
                    legend = " < " + d.maxVal;
                } else if (d.minVal && !parseFloat(d.maxVal)) {
                    legend = " >= " + d.minVal;
                } else {
                    legend = d.minVal + " - " + d.maxVal;
                }

                $legend_div.append("<label class='map_legend_label'>" +
                    "<label class='map_legend_color' style='background-color:" +
                    d.color +
                    ";'></label>" +
                    legend +
                    "</label><br/>");
            });
        }

        $legend_div.append("<label class='map_legend_label'>" +
            "<label class='map_legend_color' style='border:1px solid #eee; background-color:" +
            noDataClass +
            ";'> </label>No data</label><br/>");

        $("#map_legend_colors").append($legend_div);


        $("#admin_sban").prop("checked", true);
        //add_admin_boundary("sban");

        $("input[type='checkbox'].multi-chkbx.admin").each(function () {
            if (this.checked) {
                add_admin_boundary($(this).prop("id").replace("admin_", ""));
            }
        });

        $("input[type='checkbox'].multi-chkbx.other_layer").each(function () {
            if (this.checked) {
                add_other_layer($(this).prop("id"), $(this).attr("data"));
            }
        });

    });


}

function mapDataStyle(feature) {

    var adminFieldCode = adminCode + "_code", dataValue;

    var polyOptions = $.extend(true, {}, polyDefaultOptions);

    //polyOptions.pane = "data-layer";

    if (!feature.properties[adminFieldCode] || !legendTheme) {
        return polyOptions;
    }

    map_data.some(function (data, i) {
        return data.geo_code == feature.properties[adminFieldCode]
            ? ((dataValue = data.data_value), true)
            : ((dataValue = "no data"), false);
    });


    if ($.isNumeric(dataValue)) {
        var color;
        legendTheme.some(th => ((!parseFloat(th.minVal) || dataValue >= parseFloat(th.minVal)) &&
            (!parseFloat(th.maxVal) || dataValue <= parseFloat(th.maxVal)))
            ? (color = th.color, true)
            : (color = noDataClass, false)
        );

        polyOptions.color = color ? color : noDataClass;
        polyOptions.fillColor = color ? color : noDataClass;
    } else {
        polyOptions.color = noDataClass;
        polyOptions.fillColor = noDataClass;
        polyOptions.fillOpacity = 0.8;
    }

    return polyOptions;
}

function mapDataFeatures(feature, layer) {

    var adminFieldCode = adminCode + "_code",
        adminFieldName = adminCode + "_name";

    if (!feature || !feature.properties[adminFieldName] || !feature.properties[adminFieldCode])
        return;

    var adminName = $("#admin_info option:selected").text(),
        dataName = $("#survey_info option:selected").text(),
        dataValue,
        polyCenter,
        offsetTop = 10,
        offsetLeft,
        labelClass,
        labelContent,
        labelInfo,
        popupContent,
        dataLink = "",
        queryStr = "?equipmentId=1",
        table = $("#map_legend_infos table.table");

    var dataAdminName = feature.properties[adminFieldName];
    var currAdminCode = feature.properties[adminFieldCode];

    map_data.some(function (data, i) {
        return data.geo_code == currAdminCode
            ? ((dataValue = data.data_value), true)
            : ((dataValue = "no data"), false);
    });

    polyCenter = new L.LatLng(feature.properties["CNT_LAT"], feature.properties["CNT_LONG"]);

    offsetLeft = (dataAdminName.length - 2 > dataValue.length)
        ? (2.75 * dataAdminName.length)
        : (3.25 * dataValue.length);

    labelClass = "map_label";
    if (feature.properties["div_code"]) {
        labelClass += " div_" + feature.properties["div_code"];
        queryStr += "&divCode=" + feature.properties["div_code"];
    }
    if (feature.properties["dist_code"]) {
        labelClass += " dist_" + feature.properties["dist_code"];
        queryStr += "&distCode=" + feature.properties["dist_code"];
    }
    if (feature.properties["upaz_code"]) {
        labelClass += " upaz_" + feature.properties["upaz_code"];
        queryStr += "&upazCode=" + feature.properties["upaz_code"];
    }
    if (feature.properties["upaz_code"]) {
        labelClass += " upaz_" + feature.properties["upaz_code"];
        queryStr += "&upazCode=" + feature.properties["upaz_code"];
    }
    //dataLink = '<a asp-area="" asp-controller="SurveyInfoes" asp-action="Add" asp-route-equipmentId="1">Low Lift Pump</a>';
    //dataLink = "<a href='../SurveyInfoes?equipmentId=1'>data</a>";

    labelContent = dataAdminName + "<p style='text-align:center; font-weight:bold; color:#025;'>(" + dataValue + ")</p>";

    popupContent = "<p style='text-align:center; font-weight:bold; font-size:14px; color:#137;'>" + dataAdminName + " " + adminName +
        "</p> <p style='text-align:center; font-weight:bold; color:#024;'>(" + dataValue + ")</p>";
    dataLink = "<p style='text-align:center;'><a target='_blank' href='" + baseUrl + queryStr + "'>data source</a></p>";

    labelInfo = new L.Marker(polyCenter, {
        pane: "label-layer",
        icon: L.divIcon({
            iconSize: null,
            className: labelClass,
            iconAnchor: [offsetLeft, offsetTop],
            html: labelContent
        })
    }).bindPopup(popupContent + dataLink)
        .on({
            "mouseover": function (e) {
                layer.setStyle({
                    weight: 2.5,
                    opacity: 1.0
                });
            },
            "mouseout": function (e) {
                layer.setStyle({
                    weight: 1.0,
                    opacity: 0.9
                });
            }
        });

    mapLabels.addLayer(labelInfo);

    layer.on({
        "click": function (e) {
            L.popup().setLatLng(polyCenter).setContent(popupContent + dataLink).openOn(map);
        },
        "mouseover": function (e) {
            this.setStyle({
                weight: 2.5,
                opacity: 1.0
            });
        },
        "mouseout": function (e) {
            this.setStyle({
                weight: 1.0,
                opacity: 0.9
            });
        }
    });


    table.append("<tr><td style='padding-left:8px; text-align:left;'>" +
        dataAdminName +
        "</td> <td style='padding-right:8px; text-align:right;'>" +
        dataValue +
        "</td></tr>");

    return;
}



function remove_other_layer(layerCode) {
    if (!layerCode) return;

    if (otherLayers[layerCode] && map.hasLayer(otherLayers[layerCode].layer)) {
        map.removeLayer(otherLayers[layerCode].layer);

        $("#admin_label_" + layerCode).prop("disabled", true);

        if (map.hasLayer(otherLayers[layerCode].label))
            map.removeLayer(otherLayers[layerCode].label);
    }

    if (otherLayers[layerCode] && map.hasLayer(otherLayers[layerCode].layer)) {
        map.removeLayer(otherLayers[layerCode].layer);

        $("#admin_label_" + layerCode).prop("disabled", true);

        if (map.hasLayer(otherLayers[layerCode].label))
            map.removeLayer(otherLayers[layerCode].label);
    }

    if ($("div#map_legend_" + layerCode)) {
        $("div#map_legend_" + layerCode).slideUp(350);
        //$("div#map_legend_" + layerCode).css("display", "none");
    }


    //if ($("div.map_legend_" + layerCode)) {
    //    $("div.map_legend_" + layerCode).remove();
    //}

    //if ($(".map_legend_" + layerCode)) {
    //    console.log(this);
    //    $(".map_legend_" + layerCode).each(function () {
    //        console.log(this);
    //        $(this).remove();
    //    });
    //}

    return;
}

function add_other_layer(layerCode, dataCode) {

    if (otherLayers[layerCode]) {

        if (map.hasLayer(otherLayers[layerCode].layer))
            map.removeLayer(otherLayers[layerCode].layer);

        map.addLayer(otherLayers[layerCode].layer);

        //admin-label
        $("#admin_label_" + layerCode).prop("disabled", false);

        if ($("#admin_label_" + layerCode).prop("checked"))
            map.addLayer(otherLayers[layerCode].label);

        if ($("div#map_legend_" + layerCode)) {
            $("div#map_legend_" + layerCode).slideDown(350);
            //$("div#map_legend_" + layerCode).css("display", "");
        }

        return;
    }


    var otherLayerPath = "../js/maps/map_data/" + layerCode + ".json";

    $.getJSON(otherLayerPath,
        function (map_layer) {
            if (!map_layer) return;

            other_data = dataCode
                ? map_layer.features.map(function (f, c) {
                    if (f && f.properties[dataCode])
                        return f.properties[dataCode];
                })
                : null;

            legendTheme = legend_themes[layerCode]
                ? legend_themes[layerCode]
                : get_unique_theme(other_data);


            if (legendTheme && legendTheme.length > 0) {
                noDataClass = legendTheme[legendTheme.length - 1].color;
                legendTheme.splice(-1, 1);
            }




            //var canvasLayer = new L.CanvasGeojsonLayer();
            ///**
            // * This is just shorthand for creating a bunch of L.CanvasFeature 
            // * or L.CanvasFeatureCollection objects from your geojson
            // */
            //canvasLayer.addCanvasFeatures(L.CanvasFeatureFactory(map_layer));

            //// add to map
            //canvasLayer.addTo(map);

            //// first render
            //canvasLayer.render();



            //map.createPane("data_pane").style.zIndex = 720;
            mapLabels = new L.LayerGroup();

            otherLayer = L.geoJson(map_layer,
                {
                    style:
                        function (feature) {
                            return otherDataStyle(feature, dataCode, legendTheme);
                        } /*otherDataStyle(feature, dataCode, legendTheme)*/ /**/,
                    onEachFeature: mapOtherDataFeatures,
                    renderer: new L.Canvas({ padding: 0.5, pane: "other-layer" })
                });

        }).done(function (e) {

            otherLayers[layerCode] = { layer: otherLayer, label: otherLabels };

            map.addLayer(otherLayers[layerCode].layer);


            $("#admin_label_" + layerCode).prop("disabled", false);

            if ($("#admin_label_" + layerCode).prop("checked"))
                map.addLayer(otherLayers[layerCode].label);


            if ($("div#map_legend_" + layerCode)) {
                $("div#map_legend_" + layerCode).remove();
            }

            if (legendTheme && legendTheme.length > 0) {

                var $legend_div = $("<div id='map_legend_" + layerCode + "' style='margin-top:10px;'></div>");

                var $label = $("label[for='" + layerCode + "']");

                if ($label) {
                    $legend_div.append("<label class='map_legend_label' style='border-bottom:2px solid #17b; width:100%; font-size:15px; color:#04a;'> ▣ " + $label.text() + "</label><br/>");
                }

                legendTheme.map(function (th, i) {
                    $legend_div.append("<label class='map_legend_label'>" +
                        "<label class='map_legend_color' style='background-color:" +
                        th.color +
                        ";'></label>" +
                        th.title +
                        "</label><br/>");
                });

                $("#map_legend_colors").append($legend_div);
            }

        });

}


//(feature, dataCode, legendTheme)
function otherDataStyle(feature, dataCode, legTheme) {

    var polyOptions = $.extend(true, {}, polyDefaultOptions);

    polyOptions.pane = "other-layer";

    if (!feature || !feature.properties[dataCode] || !legTheme) {
        return polyOptions;
    }

    var color, dataValue = feature.properties[dataCode];

    legTheme.some(th => (th.val && dataValue == th.val)
        ? (color = th.color, true)
        : (color = noDataClass, false)
    );

    polyOptions.color =
        polyOptions.fillColor = color ? color : noDataClass;

    polyOptions.opacity =
        polyOptions.fillOpacity = 0.95;

    return polyOptions;
}


function mapOtherDataFeatures(feature, layer) {

    //layer.pane = "data_pane";
    return;

    var adminFieldCode = adminCode + "_code",
        adminFieldName = adminCode + "_name";

    if (!feature || !feature.properties[adminFieldName] || !feature.properties[adminFieldCode])
        return;

    var adminName = $("#admin_info option:selected").text(),
        dataName = $("#survey_info option:selected").text(),
        dataValue,
        polyCenter,
        offsetTop = 10,
        offsetLeft,
        labelClass,
        labelContent,
        labelInfo,
        popupContent,
        dataLink = "",
        queryStr = "?equipmentId=1",
        table = $("#map_legend_infos table.table");

    var dataAdminName = feature.properties[adminFieldName];
    var currAdminCode = feature.properties[adminFieldCode];

    map_data.some(function (data, i) {
        return data.geo_code == currAdminCode
            ? ((dataValue = data.data_value), true)
            : ((dataValue = "no data"), false);
    });

    polyCenter = new L.LatLng(feature.properties["CNT_LAT"], feature.properties["CNT_LONG"]);

    offsetLeft = (dataAdminName.length - 2 > dataValue.length)
        ? (2.75 * dataAdminName.length)
        : (3.25 * dataValue.length);

    labelClass = "map_label";
    if (feature.properties["div_code"]) {
        labelClass += " div_" + feature.properties["div_code"];
        queryStr += "&divCode=" + feature.properties["div_code"];
    }
    if (feature.properties["dist_code"]) {
        labelClass += " dist_" + feature.properties["dist_code"];
        queryStr += "&distCode=" + feature.properties["dist_code"];
    }
    if (feature.properties["upaz_code"]) {
        labelClass += " upaz_" + feature.properties["upaz_code"];
        queryStr += "&upazCode=" + feature.properties["upaz_code"];
    }
    if (feature.properties["upaz_code"]) {
        labelClass += " upaz_" + feature.properties["upaz_code"];
        queryStr += "&upazCode=" + feature.properties["upaz_code"];
    }
    //dataLink = '<a asp-area="" asp-controller="SurveyInfoes" asp-action="Add" asp-route-equipmentId="1">Low Lift Pump</a>';
    //dataLink = "<a href='../SurveyInfoes?equipmentId=1'>data</a>";

    labelContent = dataAdminName + "<p style='text-align:center; font-weight:bold; color:#025;'>(" + dataValue + ")</p>";

    popupContent = "<p style='text-align:center; font-weight:bold; font-size:14px; color:#137;'>" + dataAdminName + " " + adminName +
        "</p> <p style='text-align:center; font-weight:bold; color:#024;'>(" + dataValue + ")</p>";
    dataLink = "<p style='text-align:center;'><a target='_blank' href='" + baseUrl + queryStr + "'>data source</a></p>";

    labelInfo = new L.Marker(polyCenter, {
        pane: "label-layer",
        icon: L.divIcon({
            iconSize: null,
            className: labelClass,
            iconAnchor: [offsetLeft, offsetTop],
            html: labelContent
        })
    }).bindPopup(popupContent + dataLink)
        .on({
            "mouseover": function (e) {
                layer.setStyle({
                    weight: 2.5,
                    opacity: 1.0
                });
            },
            "mouseout": function (e) {
                layer.setStyle({
                    weight: 1.0,
                    opacity: 0.9
                });
            }
        });

    mapLabels.addLayer(labelInfo);

    layer.on({
        "click": function (e) {
            L.popup().setLatLng(polyCenter).setContent(popupContent + dataLink).openOn(map);
        },
        "mouseover": function (e) {
            this.setStyle({
                weight: 2.5,
                opacity: 1.0
            });
        },
        "mouseout": function (e) {
            this.setStyle({
                weight: 1.0,
                opacity: 0.9
            });
        }
    });


    table.append("<tr><td style='padding-left:8px; text-align:left;'>" +
        dataAdminName +
        "</td> <td style='padding-right:8px; text-align:right;'>" +
        dataValue +
        "</td></tr>");

    return;
}





function add_remove_admin_label(adminCode, isShow) {

    if (!adminCode || !adminLayers[adminCode] || !adminLayers[adminCode].label)
        return;

    if (isShow && !map.hasLayer(adminLayers[adminCode].label)) {
        map.addLayer(adminLayers[adminCode].label);
        return;
    }

    if (!isShow && map.hasLayer(adminLayers[adminCode].label)) {
        map.removeLayer(adminLayers[adminCode].label);
        return;
    }

    return;
}

function remove_admin_boundary(adminCode) {
    if (!adminCode) return;

    if (adminLayers[adminCode] && map.hasLayer(adminLayers[adminCode].layer)) {
        map.removeLayer(adminLayers[adminCode].layer);

        $("#admin_label_" + adminCode).prop("disabled", true);

        if (map.hasLayer(adminLayers[adminCode].label))
            map.removeLayer(adminLayers[adminCode].label);
    }

    if ($("div#map_legend_" + adminCode)) {
        $("div#map_legend_" + adminCode).remove();
    }

    return;
}

function add_admin_boundary(adminCode) {
    if (!adminCode) return;

    var lineStyle = {
        pane: "admin-layer",
        color: "#5A3322",
        weight: 1.0,
        opacity: 1,
        scale: 0.5,
        fill: false,
        fillColor: null,
        fillOpacity: 0.0
    };

    switch (adminCode) {
        case "div":
            lineStyle.zIndex = 107;
            lineStyle.dashArray = "7 3 2 4 2 3";
            lineStyle.color = "#3A2211";
            lineStyle.weight = 1.5;
            lineStyle.scale = 1.5;

            $("#map_legend_colors").append("<div id='map_legend_div'><label class='map_legend_label'>" +
                "<svg height='15' width='36'> <g fill='none' stroke='#3A2211'> <path stroke-width='1.5' stroke='#3A2211' stroke-linecap='round' stroke-dasharray='5 3 2 3 2 3' d='M7 11 l025 0' /> </g>" +
                "<label class='map_legend_color' style='height:0; border: 1px dashed #3A2211;'></label> </svg>" +
                "▣ Division Boundary</label> <br /><div>");

            //$("#map_legend_colors").append("<div id='map_legend_div'><label class='map_legend_label'>" +
            //    "<label class='map_legend_color' style='height:0; border: 1px dashed #3A2211;'></label>" +
            //    "▣ Division Boundary</label> <br /><div>");
            break;

        case "dist":
            lineStyle.zIndex = 105;
            lineStyle.dashArray = "5 2 1 3 1 2";
            lineStyle.color = "#5A3322";
            lineStyle.weight = 1.0;
            lineStyle.scale = 1.0;

            $("#map_legend_colors").append("<div id='map_legend_dist'><label class='map_legend_label'>" +
                "<svg height='15' width='36'> <g fill='none' stroke='#5A3322'> <path stroke-width='1.0' stroke='#5A3322' stroke-linecap='round' stroke-dasharray='5 2 1 3 1 2' d='M7 11 l025 0' /> </g>" +
                "<label class='map_legend_color' style='height:0; border-top: 1px dashed #5A3322;'></label> </svg>" +
                "☐ District Boundary</label> <br /><div>");

            //$("#map_legend_colors").append("<div id='map_legend_dist'><label class='map_legend_label'>" +
            //    "<label class='map_legend_color' style='height:0; border-top: 1px dashed #5A3322;'></label>" +
            //    "☐ District Boundary</label> <br /><div>");
            break;

        case "upaz":
            lineStyle.zIndex = 103;
            lineStyle.dashArray = "3 2";
            lineStyle.color = "#4A0000";
            lineStyle.weight = 0.5;
            lineStyle.scale = 0.7;

            $("#map_legend_colors").append("<div id='map_legend_upaz'><label class='map_legend_label'>" +
                "<svg height='15' width='36'> <g fill='none' stroke='#4A0000'> <path stroke-width='0.7' stroke='#4A0000' stroke-linecap='round' stroke-dasharray='2 3' d='M7 11 l025 0' /> </g>" +
                "<label class='map_legend_color' style='height:1px; background-color:#4A0000;'></label> </svg>" +
                "⚀ Upazila Boundary </label> <br /><div>");
            break;

        case "union":
            lineStyle.zIndex = 102;
            lineStyle.dashArray = "2 4";
            lineStyle.color = "#AA5533";
            lineStyle.weight = 0.5;
            lineStyle.scale = 0.5;

            $("#map_legend_colors").append("<div id='map_legend_union'><label class='map_legend_label'>" +
                "<svg height='15' width='36'> <g fill='none' stroke='#AA5533'> <path stroke-width='0.5' stroke='#AA5533' stroke-linecap='round' stroke-dasharray='2 3' d='M7 11 l025 0' /> </g>" +
                "<label class='map_legend_color' style='height:1px; background-color:#AA5533;'></label> </svg>" +
                "☉ Union Boundary </label> <br /><div>");
            break;

        case "sban":
            lineStyle.zIndex = 102;
            lineStyle.dashArray = "";
            lineStyle.color = "#228800";
            lineStyle.fill = true;
            lineStyle.fillColor = "#22BB00";
            lineStyle.fillOpacity = 0.85;
            lineStyle.weight = 0.5;
            lineStyle.scale = 0.5;

            $("#map_legend_colors").append("<div id='map_legend_sban'><label class='map_legend_label'>" +
                "<label class='map_legend_color' style='background-color:#22AA00;'></label>" +
                "Sundarban Area </label> <br /><div>");
            break;

        default:
            break;
    }

    if (adminLayers[adminCode]) {

        if (map.hasLayer(adminLayers[adminCode].layer))
            map.removeLayer(adminLayers[adminCode].layer);

        map.addLayer(adminLayers[adminCode].layer);

        //admin-label
        $("#admin_label_" + adminCode).prop("disabled", false);

        if ($("#admin_label_" + adminCode) && $("#admin_label_" + adminCode).prop("checked"))
            map.addLayer(adminLayers[adminCode].label);

        return;
    }

    var adminLayer = null,
        adminLabels = new L.LayerGroup(),
        adminLayerPath = "../js/maps/map_data/" + adminCode + ".json",
        selectedAdminCode = "30";

    //adminLayer = L.geoJSON(null, {
    adminLayer = L.geoJson(null, {
        style: lineStyle,
        onEachFeature: function (feature, layer) {
            getMapLabels(feature, layer, adminCode, adminLabels, lineStyle);
        }
        //onEachFeature: getMapLabels,
        //filter: function (feature) {
        //    return setMapFilter(feature, adminCode, selectedAdminCode);
        //}
    });


    $.getJSON(adminLayerPath, function (adminLayerInfo) {
        if (!adminLayerInfo) return;

        adminLayer.addData(adminLayerInfo);
    }).done(function (e) {
        adminLayers[adminCode] = { layer: adminLayer, label: adminLabels };

        map.addLayer(adminLayers[adminCode].layer);

        $("#admin_label_" + adminCode).prop("disabled", false);

        if (adminCode == "div" || adminCode == "dist") {
            $("#admin_label_" + adminCode).prop("checked", true);
        } else {
            var labelGroups = new L.MarkerClusterGroup({ pane: "label-layer" });
            labelGroups.addLayer(adminLabels);
            adminLayers[adminCode]["label"] = labelGroups;
        }

        if ($("#admin_label_" + adminCode).prop("checked"))
            map.addLayer(adminLayers[adminCode].label);

        //set_map_filter();
    });

    return;
}

var adminFocused = null;

function getMapLabels(feature, layer, adminCode, adminLabels, defaultStyle) {
    var adminFieldName = adminCode + "_name";

    if (!feature || !feature.properties[adminFieldName])
        return;

    defaultStyle = defaultStyle
        ? defaultStyle
        : { opacity: 1, scale: 0.5, color: "#5A3322", weight: 1.0, fill: false, fillColor: null, fillOpacity: 0.0 };

    var polyCenter,
        offsetTop = 10,
        offsetLeft,
        labelClass,
        labelContent,
        labelInfo,
        dataAdminName = feature.properties[adminFieldName],
        hoverStyle = { dashArray: null, zIndex: 9999, weight: 2.5, fill: false, color: "#FC4F3A", opacity: 1.0, fillColor: null, fillOpacity: 0.15 },
        focusStyle = { dashArray: null, zIndex: 9999, weight: 3.0, fill: true, color: "#3587EA", opacity: 1.0, fillColor: "#35A3E8", fillOpacity: 0.15 };

    polyCenter = new L.LatLng(feature.properties["CNT_LAT"], feature.properties["CNT_LONG"]);
    offsetLeft = 2.75 * dataAdminName.length;
    labelClass = "map_label";

    switch (adminCode) {
        case "div":
            defaultStyle.weight = 1.5;
            hoverStyle.weight = 2.5;

            offsetLeft = 2.75 * dataAdminName.length + 10;
            labelClass = "map_admin_label";

            labelContent = "<span style='font-size:15px;font-weight:500;color:#123;'>▣ " + dataAdminName + "</span>";
            break;

        case "dist":
            defaultStyle.weight = 1.0;
            hoverStyle.weight = 1.5;

            offsetLeft = 2.75 * dataAdminName.length + 10;
            labelClass = "map_admin_label";

            labelContent = "<span style='font-size:13px;font-weight:400;color:#137;'>☐ " + dataAdminName + "</span>";
            break;

        case "upaz":
            defaultStyle.weight = 0.5;
            hoverStyle.weight = 1.0;

            labelContent = "⚀ " + dataAdminName;
            break;

        case "union":
            defaultStyle.weight = 0.25;
            hoverStyle.weight = 1.0;
            labelContent = "☉ " + dataAdminName;
            break;

        default:
            defaultStyle.weight = 0.5;
            hoverStyle.weight = 1.0;

            labelContent = dataAdminName;
            break;
    }

    labelInfo = new L.Marker(polyCenter, {
        pane: "label-layer",
        icon: L.divIcon({
            iconSize: null,
            className: labelClass,
            iconAnchor: [offsetLeft, offsetTop],
            html: labelContent
        })
    }).on({
        "mouseover": function (e) {
            var isFocus = layer.className && layer.className == "focused";
            layer.setStyle(isFocus ? focusStyle : hoverStyle);
        },
        "mouseout": function (e) {
            var isFocus = layer.className && layer.className == "focused";
            layer.setStyle(isFocus ? focusStyle : defaultStyle);
        }
    });

    layer.on({
        "click": function (e) {

            if (layer.className && layer.className == "focused") {
                layer.className = "";
                layer.setStyle(hoverStyle);
            }

            if (adminFocused && adminFocused.layer && adminFocused.layer == layer) {
                adminFocused.layer.className = "";
                adminFocused.layer.setStyle(defaultStyle);

                adminFocused = null;
            }
        }
    });


    if (adminCode == "div" || adminCode == "dist") {

        labelInfo.on("click", function (e) {
            //console.log(layer);
            ////layer.remove();
            //console.log(layer.pane);
            //layer.styles.zIndex = 9999;
            //console.log(e.target);
            //return;

            if (adminFocused && adminFocused.layer && adminFocused.layer != layer) {
                adminFocused.layer.className = "";
                adminFocused.layer.setStyle(defaultStyle);
            }
            adminFocused = null;

            if (layer.className && layer.className == "focused") {
                layer.className = "";
                layer.setStyle(hoverStyle);

                //layer.setZIndex(400);
                //layer.setZIndexOffset(0);
                return;
            }

            layer.className = "focused";
            layer.setStyle(focusStyle);
            //layer.setZIndex(450);
            //layer.setZIndexOffset(250);

            adminFocused = { layer: layer, label: labelInfo };

            var geoCode = feature.properties[adminCode + "_code"],
                zoomLevel = (geoCode && (geoCode == 20 || geoCode == 30 || geoCode == 40)) ? 7.5 : 8.5;

            //zoomLevel = map.getZoom() > zoomLevel ? map.getZoom() : zoomLevel;
            //zoomLevel = adminCode == "dist" ? zoomLevel + 1.5 : zoomLevel;
            zoomLevel = map.getZoom() > zoomLevel
                ? map.getZoom()
                : adminCode == "dist"
                    ? zoomLevel + 1.5 : zoomLevel;

            map.setView(polyCenter, zoomLevel);
        });
    }

    adminLabels.addLayer(labelInfo);

    return;
}


function setMapFilter(feature, adminCode, selectedAdminCode) {
    //return true;
    //console.log(feature.properties[adminCodeField]);

    var adminCodeField = adminCode + "_code";

    if (!feature || !feature.properties[adminCodeField] || feature.properties[adminCodeField] != selectedAdminCode)
        return false;
    else
        return true;

}


function set_map_filter() {

    var adminCode = "div",
        selectedAdminCode = "30";

    console.log(adminCode);

    if (dataLayer && map.hasLayer(dataLayer)) {
        map.removeLayer(dataLayer);

        console.log("dataLayer");
        dataLayer.filter = function (feature, layer) {
            var adminCode = "div",
                selectedAdminCode = "30";
            return setMapFilter(feature, adminCode, selectedAdminCode);
        };

        //map.addLayer(dataLayer);
    }


    if (adminLayers[adminCode] && adminLayers[adminCode].layer && map.hasLayer(adminLayers[adminCode].layer)) {
        map.removeLayer(adminLayers[adminCode].layer);

        console.log("adminLayers");

        adminLayers[adminCode].layer.filter = function (feature, layer) {
            return setMapFilter(feature, adminCode, selectedAdminCode);
        };

        //map.addLayer(adminLayers[adminCode].layer);
    }

    return;
}

// GeoTIFF
function tt() {
    //return;

    console.log("tif...");

    var tiff = "../js/maps/map_data/temp.tiff";
    var tif = "../js/maps/map_data/GW Level (m)1.tif";

    /* Temperature and Geopotencial Height in GeoTIFF with 2 bands */
    d3.request(tiff).responseType('arraybuffer').get(
        function (error, tiffData) {

            // Geopotential height (BAND 0)
            //var geo = L.ScalarField.fromGeoTIFF(tiffData.response, bandIndex = 0);
            var geo = L.scalarField.fromGeoTIFF(tiffData.response, bandIndex = 0);

            var layerGeo = L.canvasLayer.scalarField(geo, {
                color: chroma.scale('RdPu').domain(geo.range),
                opacity: 0.65
            }).addTo(map);
            layerGeo.on('click', function (e) {
                console.log(e);
                if (e.value !== null) {
                    var v = e.value.toFixed(0);
                    var html = (`<span class="popupText">Geopotential height ${v} m</span>`);
                    var popup = L.popup()
                        .setLatLng(e.latlng)
                        .setContent(html)
                        .openOn(map);

                    console.log(html);
                }
            });

            // Temperature (BAND 1)
            var t = L.scalarField.fromGeoTIFF(tiffData.response, bandIndex = 1);
            var layerT = L.canvasLayer.scalarField(t, {
                color: chroma.scale('OrRd').domain(t.range),
                opacity: 0.65
            });
            layerT.on('click', function (e) {
                console.log(e);
                if (e.value !== null) {
                    var v = e.value.toFixed(1);
                    var html = (`<span class="popupText">Temperature ${e.value.toFixed(2)} ยบC</span>`);
                    var popup = L.popup()
                        .setLatLng(e.latlng)
                        .setContent(html)
                        .openOn(map);
                    console.log(html);
                }
            });

            L.control.layers({
                "Geopotential Height": layerGeo,
                "Temperature": layerT
            }, {}, {
                    position: 'bottomleft',
                    collapsed: false
                }).addTo(map);

            //map.fitBounds(layerGeo.getBounds());

        });

    //return;

    var gwLevel = L.leafletGeotiff(
        url = tiff,
        options = {
            band: 0,
            displayMin: 0,
            displayMax: 30,
            name: "Wind speed",
            colorScale: "rainbow",
            clampLow: false,
            clampHigh: true,
            //vector:true,
            arrowSize: 20,
        }
    ).addTo(map);


    fetch(tiff).then(r => r.arrayBuffer()).then(function (buffer) {
        console.log(buffer);

        var s = L.ScalarField.fromGeoTIFF(buffer),
            layer = L.canvasLayer.scalarField(s).addTo(map);
        console.log(s);
        console.log(layer);
        layer.on("click",
            function (e) {
                console.log(e);
                if (e.value !== null) {
                    var popup = L.popup()
                        .setLatLng(e.latlng)
                        //.setContent("${e.value}")
                        .setContent(`${e.value}`)
                        .openOn(map);
                }
            });

        map.fitBounds(layer.getBounds());
    });

}

/*

var BigPointLayer = new L.CanvasLayer.extend({

    renderCircle: function (ctx, point, radius) {
        ctx.fillStyle = 'rgba(255, 60, 60, 0.2)';
        ctx.strokeStyle = 'rgba(255, 60, 60, 0.9)';
        ctx.beginPath();
        ctx.arc(point.x, point.y, radius, 0, Math.PI * 2.0, true, true);
        ctx.closePath();
        ctx.fill();
        ctx.stroke();
    },

    render: function () {
        var canvas = this.getCanvas();
        var ctx = canvas.getContext('2d');

        // clear canvas
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        // get center from the map (projected)
        var point = this._map.latLngToContainerPoint(new L.LatLng(0, 0));

        // render
        this.renderCircle(ctx, point, (1.0 + Math.sin(Date.now() * 0.001)) * 300);

        this.redraw();

    }
});

var layer = new BigPointLayer();
layer.addTo(map);

*/

