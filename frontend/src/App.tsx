import { useEffect, useState } from "react";
import type { FieldReport } from "./types/FieldReport";
import "./App.css";
import { getReports } from "./api/reportsApi";

function App() {
    const [reports, setReports] = useState<FieldReport[]>([]);
    const [error, setError] = useState(false);
    const [isLoading, setIsLoading] = useState(true);

    /* eslint-disable react-hooks/set-state-in-effect */
    useEffect(() => {
        setError(false);
        setIsLoading(true);

        getReports()
            .then(setReports)
            .catch(() => setError(true))
            .finally(() => setIsLoading(false));
    }, []);
    /* eslint-enable react-hooks/set-state-in-effect */

    if (error) {
        return <p>Failed to load reports</p>;
    }

    if (isLoading) {
        return <p>Loading...</p>;
    }

    if (reports.length === 0 && !isLoading) {
        return <p>No reports found</p>;
    }

    return (
        <div style={{ padding: "2rem" }}>
            <h1>FieldOpsTracker</h1>

            <ul>
                {reports.map(r =>
                    <li key={r.id}>
                        <strong>{r.siteName}</strong> - {r.summary}
                    </li>
                ) }
            </ul>
        </div>
    );
}

export default App;