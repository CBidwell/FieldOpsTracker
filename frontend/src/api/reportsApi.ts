import type { FieldReport } from "../types/FieldReport";
const baseUrl = import.meta.env.VITE_API_BASE_URL;

export async function getReports(): Promise<FieldReport[]> {

    const res = await fetch(`${baseUrl}/api/reports`);

    if (!res.ok) {
        throw new Error("Failed to fetch reports");
    }

    return res.json();  
}