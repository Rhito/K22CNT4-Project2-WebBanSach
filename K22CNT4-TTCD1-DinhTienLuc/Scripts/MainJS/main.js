
// Slider

var slider = new Swiper(".mySwiper", {
    spaceBetween: 30,
    slidesPerView: 1,
    centeredSlides: true,
    grabCursor: true,
    lazy: true,
    loop: true,
    autoplay: {
        delay: 2500,
        disableOnInteraction: true
    }, 
    
});


let swiper = new Swiper(".sw", {
    lazy: true,

    slidesPerView: 6, // Hiển thị 5 phần tử
    grabCursor: true, // Hiển thị con trỏ dạng kéo
    loop: true, // Cho phép lặp lại slide
    keyboard: {
        enabled: true, // Cho phép điều khiển bằng bàn phím
    },
    navigation: {
        nextEl: ".swiper-button-next", // Nút "Tiếp theo"
        prevEl: ".swiper-button-prev", // Nút "Quay lại"
    },
});


