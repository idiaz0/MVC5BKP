/**
 * Template Name: INSPINIA - Multipurpose Admin & Dashboard Template
 * By (Author): WebAppLayers
 * Module/App (File Name): Main App JS File
 * Version: 4.2.0
 */

//
// ------------------------------ Required main scripts ------------------------------
//

$(document).ready(function(){
   

    class Plugins {
        init() {
            // comment or remove plugins you don't need
            this.initFlatPicker();
            
        }

        // Flatpickr / Timepickr
        initFlatPicker() {
            document.querySelectorAll("[data-provider]").forEach((item) => {
                const type = item.getAttribute("data-provider");
                const attrs = item.attributes;
                const dateConfig = { disableMobile: true, defaultDate: new Date() };
                
                if (type === "flatpickr") {
                    if (attrs["data-date-format"])
                        dateConfig.dateFormat = attrs["data-date-format"].value;
                    if (attrs["data-enable-time"]) {
                        dateConfig.enableTime = true;
                        dateConfig.dateFormat += " H:i";
                    }
                    if (attrs["data-altFormat"]) {
                        dateConfig.altInput = true;
                        dateConfig.altFormat = attrs["data-altFormat"].value;
                    }
                    if (attrs["data-minDate"])
                        dateConfig.minDate = attrs["data-minDate"].value;
                    if (attrs["data-maxDate"])
                        dateConfig.maxDate = attrs["data-maxDate"].value;
                    if (attrs["data-default-date"])
                        dateConfig.defaultDate = attrs["data-default-date"].value;
                    if (attrs["data-multiple-date"]) dateConfig.mode = "multiple";
                    if (attrs["data-range-date"]) dateConfig.mode = "range";
                    if (attrs["data-inline-date"]) {
                        dateConfig.inline = true;
                        dateConfig.defaultDate = attrs["data-default-date"].value;
                    }
                    if (attrs["data-disable-date"]) {
                        dateConfig.disable = attrs["data-disable-date"].value.split(",");
                    }
                    if (attrs["data-week-number"]) {
                        dateConfig.weekNumbers = true;
                    }

                    flatpickr(item, dateConfig);
                } else if (type === "timepickr") {
                    const timeConfig = {
                        enableTime: true,
                        noCalendar: true,
                        dateFormat: "H:i",
                        defaultDate: new Date(),
                    };
                    if (attrs["data-time-hrs"]) timeConfig.time_24hr = true;
                    if (attrs["data-min-time"])
                        timeConfig.minTime = attrs["data-min-time"].value;
                    if (attrs["data-max-time"])
                        timeConfig.maxTime = attrs["data-max-time"].value;
                    if (attrs["data-default-time"])
                        timeConfig.defaultDate = attrs["data-default-time"].value;
                    if (attrs["data-time-inline"]) {
                        timeConfig.inline = true;
                        timeConfig.defaultDate = attrs["data-time-inline"].value;
                    }

                    flatpickr(item, timeConfig);
                }
            });
        }

    
    }


    new Plugins().init(); 
});


