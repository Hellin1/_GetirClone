import React from "react";

function YearsList() {
    const currentYear = new Date().getFullYear();
    const years = Array.from({ length: 21 }, (_, index) => currentYear + index);

    return (
        <>
            {years.map((year) => (
                <option key={year}>{year}</option>
            ))}
        </>
    );
}

export default YearsList;