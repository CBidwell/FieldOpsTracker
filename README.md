# FieldOpsTracker

**FieldOpsTracker** is a small full-stack demo application built to practice deploying a React frontend and a .NET 8 Web API to Azure with real CI/CD.  
It simulates field incident reports and intentionally prioritizes **cloud deployment, environment configuration, and real-world debugging** over feature depth.

🔗 **Live demo:**  
https://thankful-stone-00c0ee11e.4.azurestaticapps.net  
*(Yes, the URL is ridiculous. That’s Azure Static Web Apps on the free tier.)*

---

## Why this project exists

I built this project after time away from production cloud work to re-ground myself in modern Azure hosting, CI/CD, and cross-origin frontend/backend integration.

The goal wasn’t to over-engineer or chase features — it was to **ship something real**, put it on the public internet, and deal with the kinds of problems that *only* appear once an app is live (DNS quirks, CI/CD timing, environment variables, CORS, and cloud platform behavior).

This repo reflects those decisions and tradeoffs intentionally.

---

## Architecture

- **Frontend:** React (Vite), hosted on **Azure Static Web Apps**
- **Backend:** .NET 8 Web API, hosted on **Azure App Service**
- **CI/CD:** GitHub Actions (automatic deploy on push)
- **Configuration:** Environment variables for dev vs production
- **Infrastructure:** Azure free tiers only (cost-controlled)
- **Containers:** Not used yet, but architecture is container-ready

---

## Intentional tradeoffs

This project is intentionally scoped:

- **No authentication yet** — deployment, integration, and cloud plumbing came first
- **Free Azure tiers only** — cost visibility mattered
- **Explicit CORS configuration** — no `AllowAnyOrigin` shortcuts
- **No database yet** — report data is mocked to keep focus tight

These choices were made to keep the project small, shippable, and honest.

---

## Possible next steps

If this were extended further, the next logical additions would be:

- Add authentication (likely via **Azure App Service Easy Auth**)
- Introduce write-protected endpoints
- Persist reports to a database
- Add basic rate limiting and request logging

---

## Notes

This project is not meant to be production-ready software.  
It *is* meant to demonstrate practical cloud deployment, CI/CD setup, and the ability to debug real infrastructure issues calmly once an application leaves localhost.
This README was polished with AI assistance.  
The bugs, tradeoffs, and Azure-induced confusion were all handcrafted.