"use client";

import Image from "next/image";
import "./theme.color.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faLinkedin, faGithub } from "@fortawesome/free-brands-svg-icons";
import {
  faFileText,
  faExternalLinkAlt,
} from "@fortawesome/free-solid-svg-icons";
import "../lib/fontawesome";
import techStack from "./content/techStack";
import projects from "./content/projects";
import Header from "./components/Header";
import Footer from "./components/Footer";

export default function Home() {
  return (
    <div className="min-h-screen bg-gradient-light text-primary flex flex-col">
      <Header showNavigation={true} />
      <main className="flex-1 flex flex-col">
        {/* Hero Section */}
        <section
          className="flex flex-col md:flex-row items-center justify-center gap-8 max-w-7xl mx-auto w-full p-8 min-h-[30vh]"
          aria-labelledby="hero-heading"
        >
          <aside className="shrink-0" aria-label="Profile photo">
            <Image
              src="/img/profile.jpg"
              alt="Profile photo"
              width={200}
              height={200}
              className="rounded-full shadow-lg border-4 border-card"
              priority
            />
          </aside>
          <div className="flex flex-col items-center md:items-start text-center md:text-left max-w-2xl">
            <h1
              id="hero-heading"
              className="text-4xl md:text-5xl font-bold mb-4 text-primary"
            >
              Hey there, I'm Jack!
            </h1>
            <p className="text-lg md:text-xl text-secondary mb-8 leading-relaxed">
              I've spent the last decade and change building full-stack systems
              in C#, Python, and TypeScript, reviewing pull requests, mentoring
              devs, and keeping projects moving. I care deeply about clean code,
              clear communication, and not reinventing the wheel unless it's
              fun.
            </p>
            <div className="flex flex-wrap gap-4 justify-center md:justify-start">
              <a
                href="https://linkedin.com"
                target="_blank"
                rel="noopener noreferrer"
                className="inline-flex items-center gap-2 px-6 py-3 bg-blue-600 hover:bg-blue-700 text-white rounded-lg transition-colors duration-200 font-medium"
              >
                <FontAwesomeIcon icon={faLinkedin} />
                LinkedIn
              </a>
              <a
                href="https://github.com"
                target="_blank"
                rel="noopener noreferrer"
                className="inline-flex items-center gap-2 px-6 py-3 bg-gray-800 hover:bg-gray-900 text-white rounded-lg transition-colors duration-200 font-medium"
              >
                <FontAwesomeIcon icon={faGithub} />
                GitHub
              </a>
              <a
                href="/resume.pdf"
                target="_blank"
                rel="noopener noreferrer"
                className="inline-flex items-center gap-2 px-6 py-3 bg-emerald-600 hover:bg-emerald-700 text-white rounded-lg transition-colors duration-200 font-medium"
              >
                <FontAwesomeIcon icon={faFileText} />
                Resume
              </a>
            </div>
          </div>
        </section>

        {/* Tech Stack Section */}
        <section
          className="max-w-7xl mx-auto w-full p-8 flex-1 flex flex-col justify-center"
          aria-labelledby="techstack-heading"
        >
          <h2 id="techstack-heading" className="text-2xl font-semibold mb-4">
            Tech Stack
          </h2>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
            {techStack.map((group) => (
              <article key={group.category}>
                <h3 className="text-lg font-medium mb-3 text-primary">
                  {group.category}
                </h3>
                <div className="flex flex-wrap gap-2">
                  {group.items.map((item) => (
                    <span
                      key={item.name}
                      className="inline-flex items-center gap-2 px-3 py-1 bg-badge text-badge rounded-full text-sm font-medium border border-badge"
                    >
                      <Image
                        src={item.img}
                        alt={item.name + " logo"}
                        width={16}
                        height={16}
                        className="inline"
                      />
                      {item.name}
                    </span>
                  ))}
                </div>
              </article>
            ))}
          </div>
        </section>

        {/* Projects Section */}
        <section
          className="max-w-7xl mx-auto w-full p-8 mt-auto"
          aria-labelledby="projects-heading"
        >
          <h2 id="projects-heading" className="text-2xl font-semibold mb-4">
            Highlights
          </h2>
          <div className="flex flex-wrap justify-center gap-6">
            {projects.map((project) => (
              <article
                key={project.title}
                className="bg-card rounded-xl shadow-md border border-card p-6 max-w-sm w-full"
              >
                <h3 className="font-bold text-lg mb-2 text-primary">
                  {project.title}
                </h3>
                <p className="text-secondary text-sm mb-4">
                  {project.description}
                </p>
                <div className="flex gap-3">
                  <a
                    href={project.webLink}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="inline-flex items-center gap-2 px-3 py-2 bg-blue-600 hover:bg-blue-700 text-white rounded-lg transition-colors duration-200 text-sm font-medium"
                    aria-label={`Visit ${project.title} website`}
                  >
                    <FontAwesomeIcon icon={faExternalLinkAlt} />
                    Live Demo
                  </a>
                  <a
                    href={project.githubLink}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="inline-flex items-center gap-2 px-3 py-2 bg-gray-800 hover:bg-gray-900 text-white rounded-lg transition-colors duration-200 text-sm font-medium"
                    aria-label={`View ${project.title} source code`}
                  >
                    <FontAwesomeIcon icon={faGithub} />
                    GitHub
                  </a>
                </div>
              </article>
            ))}
          </div>
        </section>
      </main>
      <Footer />
    </div>
  );
}
