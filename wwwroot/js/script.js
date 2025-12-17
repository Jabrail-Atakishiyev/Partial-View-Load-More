$(document).ready(function () {

    let loadMoreBtn = document.querySelector('.btn-load-more');

    if (loadMoreBtn) {
        loadMoreBtn.addEventListener('click', function () {
            let currentCount = document.querySelectorAll(".product-item").length;
            let totalCount = document.querySelector(".product-count").value;

            fetch(`/Home/LoadMore?skip=${currentCount}`)
                .then(response => response.text())
                .then(data => {
                    document.querySelector('.load-products').innerHTML += data;

                    let newCount = document.querySelectorAll(".product-item").length;
                    if (newCount >= parseInt(totalCount)) {
                        loadMoreBtn.style.display = 'none';
                    }
                })
                .catch(error => console.error('Error:', error));
        });
    }

    $(document).on('click', '.category li a', function (e) {
        e.preventDefault();
        let category = $(this).attr('data-id');
        let products = $('.product-item');

        if (category == 'all') {
            products.parent().fadeIn();
        } else {
            products.each(function () {
                if (category == $(this).attr('data-id')) {
                    $(this).parent().fadeIn();
                } else {
                    $(this).parent().hide();
                }
            })
        }
    });

    $(document).on('click', '#search', function () {
        $(this).next().toggle();
    })

    $(document).on('click', '#mobile-navbar-show', function () {
        $('.mobile-navbar').addClass("active");
    })

    $(document).on('click', '#mobile-navbar-close', function () {
        $(this).parent().removeClass("active");
    })

    $(".slider").owlCarousel({
        items: 1,
        loop: true,
        autoplay: true
    });

    $(".instagram").owlCarousel({
        items: 4,
        loop: true,
        autoplay: true,
        responsive: {
            0: { items: 1 },
            576: { items: 2 },
            768: { items: 3 },
            992: { items: 4 }
        }
    });

    $(document).on('click', '.question', function () {
        $(this).siblings('.question').children('i').removeClass('fa-minus').addClass('fa-plus');
        $(this).siblings('.answer').not($(this).next()).slideUp();
        $(this).children('i').toggleClass('fa-plus').toggleClass('fa-minus');
        $(this).next().slideToggle();
        $(this).siblings('.active').removeClass('active');
        $(this).toggleClass('active');
    })
});