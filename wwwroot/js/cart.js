document.addEventListener("DOMContentLoaded", function() {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    const cartContainer = document.getElementById("cart-items");
    const cartTotal = document.getElementById("cart-total");

    function renderCart() {
        cartContainer.innerHTML = "";
        let total = 0;
        cart.forEach((item, index) => {
            total += item.price;
            const cartItem = document.createElement("div");
            cartItem.classList.add("cart-item", "col-12");
            cartItem.innerHTML = `
                <img src="${item.image}" alt="${item.name}">
                <h5>${item.name}</h5>
                <p>${item.price} EUR</p>
                <button class="btn btn-danger" onclick="removeFromCart(${index})">Șterge</button>
            `;
            cartContainer.appendChild(cartItem);
        });
        cartTotal.textContent = total.toFixed(2);
    }

    window.removeFromCart = function(index) {
        cart.splice(index, 1);
        localStorage.setItem("cart", JSON.stringify(cart));
        renderCart();
    };

    window.checkout = function() {
        alert("Comanda a fost plasată cu succes!");
        localStorage.removeItem("cart");
        renderCart();
    };

    renderCart();
});
