# Jack Schaible – Portfolio

This is my personal portfolio site, built with Next.js 14 and Tailwind CSS. It showcases my work, skills, and contact information in a modern, accessible, and themeable web app!

## Why I Made This

I wanted a portfolio that:

- Looks great and works well on any device
- Is easy to maintain and extend
- Lets me show off my projects, tech stack, and experience
- Supports dark/light mode with a custom theming system
- Uses modern web best practices (TypeScript, Tailwind, Next.js, FontAwesome)
- Gives me a place to share my thoughts

## Features

- **Responsive design**: Looks great on desktop and mobile
- **Theme toggle**: Switch between light and dark mode, with custom color variables
- **Project highlights**: Quick links to my best work, with live and GitHub links
- **Work-in-progress pages**: Blog, Projects, and Contact pages styled to match the main site
- **Accessible**: All interactive elements are keyboard and screen reader friendly

## Getting Started

### Prerequisites

- Node.js 18+ (LTS recommended)
- npm (comes with Node.js)

### Installation

1. Clone the repo:

   ```sh
   git clone https://github.com/JackSchaible/Profile.git
   cd Profile/App
   ```

2. Install dependencies:

   ```sh
   npm install
   ```

### Running Locally

Start the development server:

```sh
npm run dev
```

Open [http://localhost:3000](http://localhost:3000) in your browser.

### Building for Production

To build and start in production mode:

```sh
npm run build
npm start
```

## Folder Structure

- `app/` – Main Next.js app directory (pages, components, styles)
- `public/` – Static assets (images, icons)
- `lib/` – FontAwesome icon config

## Customization

- Update your projects in `app/page.tsx` or move to a data file
- Edit theme colors in `app/globals.css`
- Add new pages in the `app/` directory

## License

MIT. See [LICENSE](LICENSE) for details.

---

Made with 🌮 by Jack Schaible
