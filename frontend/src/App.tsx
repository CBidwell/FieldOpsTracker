import { useEffect, useState } from "react";
import "./App.css";

function App() {
    const [status, setStatus] = useState<string>("Loading...");
    useEffect(() => {
        fetch("http://localhost:5244/api/health")
            .then(res => res.json())
            .then(data => setStatus(data.status))
            .catch(() => setStatus("Backend unreachable"));
    }, []);

    return (
        <div style={{ padding: "2rem" }}>
            <h1>FieldOpsTracker</h1>
            <p>Backend status: <strong>{status}</strong></p>
        </div>
    );
}

export default App;