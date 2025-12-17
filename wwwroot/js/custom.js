let loadMoreBtn = document.querySelector('.btn-load-more');

if (loadMoreBtn) {
    loadMoreBtn.addEventListener('click', function () {
        // Hazırda saytda neçə məhsul-kartı var onu sayırıq
        // Qeyd: _ProductPartial daxilindəki əsas div-in class-ı nədirsə onu yazmalısan (məs: .product-item)
        let htmlProductCount = document.querySelectorAll(".load-products .product-item").length;

        // Bazada olan ümumi sayı götürürük
        let dbProductCount = document.querySelector(".product-count").value;

        // URL-də "skip=" hissəsini mütləq yazmalısan ki, Controller tanısın
        fetch(`/Home/LoadMore?skip=${htmlProductCount}`)
            .then(response => response.text())
            .then(data => {
                let container = document.querySelector('.load-products');

                // Gələn yeni məhsulları mövcud olanların sonuna əlavə edirik
                container.innerHTML += data;

                // Yeni sayını yenidən yoxlayırıq
                let newCount = document.querySelectorAll(".load-products .product-item").length;

                // Əgər gələn məhsulların sayı bazadakı ümumi saya çatdısa, düyməni gizlədirik
                if (newCount >= parseInt(dbProductCount)) {
                    this.style.display = 'none';
                }
            })
            .catch(error => console.error('Error:', error));
    });
}