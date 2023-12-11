
function MonthsList() {
    const months = Array.from({ length: 12 }, (_, index) => index + 1);

    return (
        <>
            {months.map((monthIndex) => (
                <option key={monthIndex}>{monthIndex}</option>
            ))}
        </>
    );
}

export default MonthsList;