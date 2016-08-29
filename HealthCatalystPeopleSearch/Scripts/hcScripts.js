(function($) {
    "use strict";

    $('body').scrollspy({
        target: '.navbar-fixed-top',
        offset: 60
    });

    $('#topNav').affix({
        offset: {
            top: 200
        }
    });
    
    new WOW().init();
    
    $('a.page-scroll').bind('click', function(event) {
        var $ele = $(this);
        $('html, body').stop().animate({
            scrollTop: ($($ele.attr('href')).offset().top - 60)
        }, 1450, 'easeInOutExpo');
        event.preventDefault();
    });
    
    $('.navbar-collapse ul li a').click(function() {
        /* always close responsive nav after click */
        $('.navbar-toggle:visible').click();
    });

    $('#galleryModal').on('show.bs.modal', function (e) {
       $('#galleryImage').attr("src",$(e.relatedTarget).data("src"));
    });

    $('#loadPerson').click(function () {
        var name = $('#personSearchBox').val();
        $.ajax({
            url: '/Home/LoadPerson',
            type: 'GET',
            cache: false,
            data: { name: name },
            beforeSend: function () {
                $('#personResults').hide();
                $('#loadingModal').show();
            },
            complete: function () {
                $('#personResults').show();
                $('#loadingModal').hide();
            }
        }).done(function (data) {
            $('#personResults').html(data);
        });
    });

    $('#reseedData').click(function () {
        $.ajax({
            url: '/Home/Reseed',
            type: 'GET'
        }).done(function (result) {
            if (result == "success") {
                ReloadPeopleGrid();
            }
            else
            {
                alert('Reseed failed!');
            }
        });
    });

    $(document).ready(function () {
        ProcessDelete();
    });
})(jQuery);

function PersonAdded() {
    ProcessDelete();
    $('#formAddPerson')[0].reset();
    RefreshTypeAhead();
    alert('person added');
}

function RefreshTypeAhead() {
    $('input.search-input').typeahead('destroy');
    $('input.search-input').typeahead({
        prefetch: 'GetNames',
        limit: 500
    });
}

function ReloadPeopleGrid() {
    $.ajax({
        url: '/Home/PeopleGrid',
        type: 'GET'
    }).done(function (data) {
        $('#PeopleGridDiv').html(data);
    });
}

function ProcessDelete() {
    $("button[name='DeletePerson']").click(function () {
        var yesdeleteme = confirm('Delete this person?');
        if (yesdeleteme) {
            var personId = $(this).attr("data-id");
            $.ajax({
                url: '/Home/DeletePerson',
                type: 'DELETE',
                cache: false,
                data: { PersonId: personId }
            }).done(function (data) {
                $('#PeopleGridDiv').html(data);
                RefreshTypeAhead()
                ProcessDelete();
            });
        }
    });
}

$(document).ready(function () {
    window.addEventListener("submit", function (e) {
        var form = e.target;
        if (form.getAttribute("enctype") === "multipart/form-data") {
            if (form.dataset.ajax) {
                e.preventDefault();
                e.stopImmediatePropagation();
                var xhr = new XMLHttpRequest();
                xhr.open(form.method, form.action);
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4 && xhr.status == 200) {
                        if (form.dataset.ajaxUpdate) {
                            var updateTarget = document.querySelector(form.dataset.ajaxUpdate);
                            if (updateTarget) {
                                updateTarget.innerHTML = xhr.responseText;
                                PersonAdded();
                            }
                        }
                    }
                };
                xhr.send(new FormData(form));
            }
        }
    }, true);
});