
// Slider swiper
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

var swiper = new Swiper(".sw", {
    lazy: true,

    slidesPerView: 6, // Hiển thị 6 phần tử
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


/* Sticky header */
const header = document.querySelector('header');
const nav = document.querySelector('.navbar'); // Chọn phần tử .navbar của bạn
const navHeight = nav.getBoundingClientRect().height;

const stickyNav = function (entries) {
    const [entry] = entries;

    if (!entry.isIntersecting) nav.classList.add('sticky');
    else nav.classList.remove('sticky');
};

// Tạo IntersectionObserver để theo dõi phần tử header
const headerObserver = new IntersectionObserver(stickyNav, {
    root: null,
    threshold: 0,
    rootMargin: `-${navHeight}px`, // Khoảng cách dính
});

// Kích hoạt quan sát cho phần tử header
headerObserver.observe(header);