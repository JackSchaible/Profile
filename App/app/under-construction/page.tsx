"use client";

import Link from "next/link";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faArrowLeft, faHammer } from "@fortawesome/free-solid-svg-icons";
import "../../lib/fontawesome";
import Header from "../components/Header";
import Footer from "../components/Footer";

export default function UnderConstruction() {
  return (
    <div className="min-h-screen bg-gradient-light text-primary flex flex-col">
      <Header showBackButton={true} showNavigation={false} />

      <main className="flex-1 flex flex-col items-center justify-center p-8">
        <div className="text-center max-w-2xl">
          <div className="mb-8">
            <FontAwesomeIcon
              icon={faHammer}
              className="w-24 h-24 text-muted mx-auto mb-6"
            />
          </div>
          <h1 className="text-4xl md:text-5xl font-bold mb-4 text-primary">
            Under Construction
          </h1>
          <p className="text-lg md:text-xl text-secondary mb-8 leading-relaxed">
            This page is currently being built. Check back soon for updates!
          </p>
          <div className="flex flex-wrap gap-4 justify-center">
            <Link
              href="/"
              className="inline-flex items-center gap-2 px-6 py-3 bg-blue-600 hover:bg-blue-700 text-white rounded-lg transition-colors duration-200 font-medium"
            >
              <FontAwesomeIcon icon={faArrowLeft} />
              Return Home
            </Link>
            <a
              href="https://www.linkedin.com/in/jack-schaible-352a1631/"
              target="_blank"
              rel="noopener noreferrer"
              className="inline-flex items-center gap-2 px-6 py-3 bg-blue-700 hover:bg-blue-800 text-white rounded-lg transition-colors duration-200 font-medium"
            >
              Follow for Updates
            </a>
          </div>
        </div>
      </main>

      <Footer />
    </div>
  );
}
