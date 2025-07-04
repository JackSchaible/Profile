import Link from "next/link";

export default function Footer() {
  return (
    <footer className="mt-auto py-6 text-center text-muted text-sm">
      <nav className="mb-2">
        <Link href="/" className="text-muted no-underline mr-4 hover:underline">
          Home
        </Link>
        <Link
          href="/projects"
          className="text-muted no-underline mr-4 hover:underline"
        >
          Projects
        </Link>
        <Link
          href="/blog"
          className="text-muted no-underline mr-4 hover:underline"
        >
          Blog
        </Link>
        <Link
          href="/contact"
          className="text-muted no-underline hover:underline"
        >
          Contact
        </Link>
      </nav>
      &copy; {new Date().getFullYear()} Cactus Studios. All rights reserved.
    </footer>
  );
}
