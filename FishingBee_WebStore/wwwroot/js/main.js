/*price range*/

 $('#sl2').slider();

	var RGBChange = function() {
	  $('#RGB').css('background', 'rgb('+r.getValue()+','+g.getValue()+','+b.getValue()+')')
	};	
		
/*scroll to top*/

$(document).ready(function(){
	$(function () {
		$.scrollUp({
	        scrollName: 'scrollUp', // Element ID
	        scrollDistance: 300, // Distance from top/bottom before showing element (px)
	        scrollFrom: 'top', // 'top' or 'bottom'
	        scrollSpeed: 300, // Speed back to top (ms)
	        easingType: 'linear', // Scroll to top easing (see http://easings.net/)
	        animation: 'fade', // Fade, slide, none
	        animationSpeed: 200, // Animation in speed (ms)
	        scrollTrigger: false, // Set a custom triggering element. Can be an HTML string or jQuery object
					//scrollTarget: false, // Set a custom target element for scrolling to the top
	        scrollText: '<i class="fa fa-angle-up"></i>', // Text for element, can contain HTML
	        scrollTitle: false, // Set a custom <a> title if required.
	        scrollImg: false, // Set true to use image
	        activeOverlay: false, // Set CSS color to display scrollUp active point, e.g '#00FFFF'
	        zIndex: 2147483647 // Z-Index for the overlay
		});
	});
});
//document.querySelector('form').addEventListener('submit', function (e) {
//	e.preventDefault(); // Ngăn chặn hành vi submit mặc định

//	// Lấy giá trị kích thước và độ cứng được chọn
//	const size = document.getElementById('size').value;
//	const hardness = document.getElementById('hardness').value;

//	// Hiển thị thông báo (có thể thay thế bằng chức năng thêm vào giỏ hàng)
//	alert(`Đã thêm sản phẩm với kích thước ${size} và độ cứng ${hardness} vào giỏ hàng.`);
//});
document.addEventListener("DOMContentLoaded", function () {
    let searchButton = document.getElementById("searchBtn");

    if (searchButton) {
        searchButton.addEventListener("click", function () {
            let searchInputElement = document.getElementById("searchBox");

            if (searchInputElement) {
                let keyword = searchInputElement.value.trim().toLowerCase();

                if (keyword === "") {
                    alert("Vui lòng nhập từ khóa tìm kiếm!");
                    return;
                }

                let productItems = document.querySelectorAll(".product-item");
                let found = false; // Cờ kiểm tra có sản phẩm nào phù hợp không

                productItems.forEach(item => {
                    let productNameElement = item.querySelector(".product-name");

                    if (productNameElement) {
                        let productName = productNameElement.textContent.trim().toLowerCase();

                        if (productName.includes(keyword)) {
                            item.style.display = "block"; // Hiển thị sản phẩm phù hợp
                            found = true;
                        } else {
                            item.style.display = "none"; // Ẩn sản phẩm không phù hợp
                        }
                    } else {
                        console.error("Không tìm thấy phần tử .product-name trong .product-item");
                    }
                });

                if (!found) {
                    alert("Không tìm thấy sản phẩm nào phù hợp!");
                }
            } else {
                console.error("Phần tử #searchBox không tồn tại!");
            }
        });
    }
});