"use client";

import Link from "next/link";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSun, faMoon } from "@fortawesome/free-solid-svg-icons";
import { useTheme } from "../providers/ThemeProvider";

interface HeaderProps {
  showBackButton?: boolean;
  backUrl?: string;
  showNavigation?: boolean;
}

export default function Header({
  showBackButton = false,
  backUrl = "/",
  showNavigation = true,
}: HeaderProps) {
  const { isDark, toggleTheme } = useTheme();

  return (
    <header className="w-full">
      <nav className="max-w-7xl mx-auto flex justify-between items-center gap-6 text-base py-6 px-4">
        {showBackButton ? (
          <Link
            href={backUrl}
            className="inline-flex items-center gap-2 text-primary no-underline font-medium hover:underline hover:underline-offset-4 transition-all duration-200"
          >
            <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
              <path
                fillRule="evenodd"
                d="M12.707 5.293a1 1 0 010 1.414L9.414 10l3.293 3.293a1 1 0 01-1.414 1.414l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 0z"
                clipRule="evenodd"
              />
            </svg>
            Back to Home
          </Link>
        ) : null}

        {showNavigation ? (
          <div className="flex justify-center gap-6 flex-1">
            <Link
              href="/"
              className="text-primary no-underline font-medium hover:underline hover:underline-offset-4 transition-all duration-200"
            >
              Home
            </Link>
            <Link
              href="/projects"
              className="text-primary no-underline font-medium hover:underline hover:underline-offset-4 transition-all duration-200"
            >
              Projects
            </Link>
            <Link
              href="/blog"
              className="text-primary no-underline font-medium hover:underline hover:underline-offset-4 transition-all duration-200"
            >
              Blog
            </Link>
            <Link
              href="/contact"
              className="text-primary no-underline font-medium hover:underline hover:underline-offset-4 transition-all duration-200"
            >
              Contact
            </Link>
          </div>
        ) : (
          <div className="flex-1" />
        )}

        <div className="flex items-center gap-2">
          <FontAwesomeIcon icon={faSun} className="w-5 h-5 text-yellow-500" />
          <button
            className="relative inline-flex h-6 w-11 items-center rounded-full bg-toggle transition-colors duration-200 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
            onClick={toggleTheme}
            aria-label="Toggle dark mode"
          >
            <span
              className={`inline-block h-4 w-4 transform rounded-full bg-toggle-slider transition-transform duration-200 ${
                isDark ? "translate-x-6" : "translate-x-1"
              }`}
            />
          </button>
          <FontAwesomeIcon icon={faMoon} className="w-5 h-5 text-blue-500" />
        </div>
      </nav>
    </header>
  );
}
