import type { Config } from "tailwindcss";

const config: Config = {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  darkMode: "class",
  theme: {
    extend: {
      colors: {
        background: "var(--color-bg-primary)",
        foreground: "var(--color-text-primary)",
        card: "var(--color-bg-card)",
        "card-foreground": "var(--color-text-primary)",
        muted: "var(--color-bg-secondary)",
        "muted-foreground": "var(--color-text-muted)",
        border: "var(--color-border-primary)",
        input: "var(--color-bg-secondary)",
        ring: "var(--color-border-primary)",
        secondary: "var(--color-text-secondary)",
      },
      backgroundImage: {
        "gradient-custom": "var(--gradient-bg)",
      },
      boxShadow: {
        "custom-sm": "var(--shadow-sm)",
        "custom-md": "var(--shadow-md)",
        "custom-lg": "var(--shadow-lg)",
        "custom-xl": "var(--shadow-xl)",
      },
    },
  },
  plugins: [],
};

export default config;
