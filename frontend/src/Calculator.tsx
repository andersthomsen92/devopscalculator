import { useState, useEffect } from "react";
import { http } from "./http.ts";

export default function Calculator() {
    const [calculatorType, setCalculatorType] = useState<"simple" | "cached">("simple");
    const [operation, setOperation] = useState<string>("add");
    const [a, setA] = useState<number>(0);
    const [b, setB] = useState<number | null>(null);
    const [result, setResult] = useState<number | null>(null);
    const [error, setError] = useState<string | null>(null);
    const [history, setHistory] = useState<any[]>([]); 

    const handleCalculate = async () => {
        setError(null);
        setResult(null);

        try {
            const response = await http.api.calculatorCreate(calculatorType, operation, { a, b });
            const result = (response as unknown as { data: { result: number } }).data.result;

            setResult(result);

            // After calculation, fetch the history
            fetchHistory();
        } catch (err) {
            setError("Error performing calculation. Please check inputs.");
        }
    };

    const fetchHistory = async () => {
        try {
            const response = await http.api.calculatorHistoryList();
            setHistory(response.data);
        } catch (err) {
            console.error("Error fetching history", err);
        }
    };

    useEffect(() => {
        fetchHistory();
    }, []);

    return (
        <div className="flex flex-col items-center justify-center min-h-screen bg-base-200 p-6">
            <div className="card w-full max-w-md bg-base-100 shadow-xl p-6">
                <h1 className="text-2xl font-bold text-center">Calculator</h1>

                {/* Calculator Type Selector */}
                <div className="form-control my-4">
                    <label className="label" htmlFor="calculatorType">Choose Calculator Type:</label>
                    <select
                        id="calculatorType"
                        className="select select-bordered"
                        value={calculatorType}
                        onChange={(e) => setCalculatorType(e.target.value as "simple" | "cached")}
                    >
                        <option value="simple">Simple Calculator</option>
                        <option value="cached">Cached Calculator</option>
                    </select>
                </div>

                {/* Operation Selector */}
                <div className="form-control">
                    <label className="label" htmlFor="operation">Choose Operation:</label>
                    <select
                        id="operation"
                        className="select select-bordered"
                        value={operation}
                        onChange={(e) => setOperation(e.target.value)}
                    >
                        <option value="add">Addition (+)</option>
                        <option value="subtract">Subtraction (-)</option>
                        <option value="multiply">Multiplication (×)</option>
                        <option value="divide">Division (÷)</option>
                        <option value="factorial">Factorial (!)</option>
                        <option value="isPrime">Prime Check</option>
                    </select>
                </div>

                {/* Number Inputs */}
                <div className="form-control my-4">
                    <label className="label" htmlFor="numberA">Enter Number A:</label>
                    <input
                        id="numberA"
                        type="number"
                        className="input input-bordered"
                        value={a}
                        onChange={(e) => setA(Number(e.target.value))}
                    />
                </div>

                {operation !== "factorial" && operation !== "isPrime" && (
                    <div className="form-control">
                        <label className="label" htmlFor="numberB">Enter Number B:</label>
                        <input
                            id="numberB"
                            type="number"
                            className="input input-bordered"
                            value={b ?? ""}
                            onChange={(e) => setB(e.target.value ? Number(e.target.value) : null)}
                        />
                    </div>
                )}

                {/* Calculate Button */}
                <button id="calculateButton" className="btn btn-primary mt-4" onClick={handleCalculate}>
                    Calculate
                </button>

                {/* Result Display */}
                {result !== null && (
                    <div className="alert alert-success mt-4">
                        <span id="resultDisplay">Result: {result}</span>
                    </div>
                )}

                {/* Error Message */}
                {error && (
                    <div className="alert alert-error mt-4">
                        <span>{error}</span>
                    </div>
                )}

                {/* Calculation History */}
                <div className="mt-8">
                    <h2 className="text-xl font-bold">History</h2>
                    <ul className="mt-4">
                        {history.map((entry, index) => (
                            <li key={index} className="p-2">
                                <div>{entry.text}</div>
                            </li>
                        ))}
                    </ul>
                </div>
            </div>
        </div>
    );
}
