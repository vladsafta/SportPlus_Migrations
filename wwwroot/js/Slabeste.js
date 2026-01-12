function calculateCalories() {
    const gender = document.getElementById("gender").value;
    const height = parseFloat(document.getElementById("height").value);
    const weight = parseFloat(document.getElementById("weight").value);
    const activity = parseFloat(document.getElementById("activity").value);

    if (isNaN(height) || isNaN(weight)) {
        document.getElementById("result").innerHTML = "Te rog să introduci valori valide!";
        return;
    }

    let bmr;
    if (gender === "male") {
        bmr = 88.36 + (13.4 * weight) + (4.8 * height) - (5.7 * 30);
    } else {
        bmr = 447.6 + (9.2 * weight) + (3.1 * height) - (4.3 * 30);
    }

    const dailyCalories = bmr * activity;
    document.getElementById("result").innerHTML = `Necesarul zilnic de calorii: <strong>${Math.round(dailyCalories)} kcal</strong>`;
}
