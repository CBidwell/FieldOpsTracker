const fs = require("fs");
const path = require("path");

const today = new Date().toISOString().split("T")[0];

const standupDir = path.join(__dirname, "..", "docs", "standup");
const standupFile = path.join(standupDir, `${today}.md`);

if (!fs.existsSync(standupDir)) {
  fs.mkdirSync(standupDir, { recursive: true });
}

if (fs.existsSync(standupFile)) {
  console.log(`⚠️ Standup already exists for ${today}`);
  process.exit(0);
}

const content = `# Standup — ${today}

## Project
**Did**
- 

**Doing**
- 

**Blocked**
- 
`;

fs.writeFileSync(standupFile, content, { encoding: "utf8" });

console.log(`✅ Public standup created: docs/standup/${today}.md`);
