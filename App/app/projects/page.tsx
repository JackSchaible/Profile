"use client";

import Header from "../components/Header";
import Footer from "../components/Footer";
import TechPill from "../components/TechPill";
import projects from "../content/projects";
import { TechKey } from "../content/techData";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faExternalLinkAlt } from "@fortawesome/free-solid-svg-icons";
import { faGithub } from "@fortawesome/free-brands-svg-icons";

export default function Projects() {
  return (
    <div className="min-h-screen bg-gradient-light text-primary flex flex-col">
      <Header showNavigation={true} />

      <main className="flex-1 flex flex-col">
        {/* Projects Section */}
        <section className="max-w-7xl mx-auto w-full p-8">
          <h1 className="text-4xl md:text-5xl font-bold mb-8 text-primary text-center">
            My Projects
          </h1>

          {/* Professional/Corporate Projects Section */}
          <h2 className="text-2xl md:text-3xl font-bold mb-6 text-primary">
            Professional & Corporate Projects
          </h2>
          <div className="grid gap-8 md:grid-cols-1 lg:grid-cols-2 max-w-7xl mx-auto mb-16">
            {/* OneBridge */}
            <div className="bg-card rounded-lg shadow-lg p-6 border border-card-border flex flex-col justify-between">
              <div>
                <h3 className="text-xl font-semibold mb-4 text-primary">
                  OneBridge/Irth: Cognitive Integrity Management (CIM)/Asset
                  Integrity Management (AIM)
                </h3>
                <p className="text-secondary mb-4 leading-relaxed">
                  At OneBridge / Irth Solutions I helped modernize a sprawling
                  monorepo that housed both a legacy{" "}
                  <span className="font-bold">Angular 1.x</span> application and
                  a new cloud-first platform.
                </p>

                <p className="text-secondary mb-4 leading-relaxed">
                  I co-built the <span className="italic">Control Panel</span>{" "}
                  MVP—an
                  <span className="font-bold">Angular (2+)</span> front-end with
                  a <span className="font-bold">.NET Core + GraphQL API</span>{" "}
                  backed by <span className="font-bold">SQL Server</span>—that
                  let pipeline operators manage users, facilities, and
                  inline-inspection (“pig”) reports while asynchronous
                  processing ran through{" "}
                  <span className="font-bold">Azure Functions</span> and{" "}
                  <span className="font-bold">Service Bus</span>.
                </p>
                <p className="text-secondary mb-4 leading-relaxed">
                  After handing the MVP to an offshore team and launching the
                  companion <span className="italic">Vendor Portal</span>, I
                  shifted to building a shared component{" "}
                  <span className="italic">library/dev-kit</span> (think Angular
                  Material-style docs), hardening CI/CD, reviewing PRs, and
                  mentoring devs—turning quick proof-of-concept code into a
                  robust, documented, multi-app foundation.
                </p>
              </div>

              <div>
                <div className="flex flex-wrap gap-2 mb-4">
                  <TechPill tech={TechKey.CSHARP} />
                  <TechPill tech={TechKey.ANGULAR} />
                  <TechPill tech={TechKey.AZURE} />
                  <TechPill tech={TechKey.GRAPHQL} />
                </div>
                <p className="text-sm text-muted">
                  Proprietary corporate software - code not available for public
                  viewing
                </p>
              </div>
            </div>

            {/* LAIKA */}
            <div className="bg-card rounded-lg shadow-lg p-6 border border-card-border flex flex-col justify-between">
              <div>
                <h3 className="text-xl font-semibold mb-4 text-primary">
                  Various Apps
                </h3>
                <p className="text-secondary mb-4 leading-relaxed">
                  At LAIKA, I worked across a wide tech stack—primarily React
                  and Rust, but also Python (Django, Flask) and even
                  Scala—building internal tools for stop-motion film production.
                  Our backend data layer was handled entirely by ShotGrid, so
                  each app was tailored to a specific department's workflow.
                </p>
                <p className="text-secondary mb-4 leading-relaxed">
                  My first major project was EOD (End of Days), an app used by
                  assistant directors to log end-of-day notes about active
                  stages and shots.
                </p>
                <p className="text-secondary mb-4 leading-relaxed">
                  I also helped transition the Big Boards scheduling tool from
                  Scala to Rust/React, enabling schedulers to plan which shots
                  would be filmed on which stages, by which animators, and with
                  which support teams.
                </p>
                <p className="text-secondary mb-4 leading-relaxed">
                  These apps were highly collaborative and directly supported
                  daily production operations across the studio. In addition to
                  hands-on development, I also acted as the Agile team lead,
                  helping prioritize work, unblock teammates, and keep projects
                  on track.
                </p>
              </div>

              <div>
                <div className="flex flex-wrap gap-2 mb-4">
                  <TechPill tech={TechKey.PYTHON} />
                  <TechPill tech={TechKey.REACT} />
                  <TechPill tech={TechKey.GRAPHQL} />
                  <TechPill tech={TechKey.DJANGO} />
                  <TechPill tech={TechKey.RUST} />
                </div>

                <p className="text-sm text-muted">
                  Proprietary corporate software - code not available for public
                  viewing
                </p>
              </div>
            </div>

            {/* AMA */}
            <div className="bg-card rounded-lg shadow-lg p-6 border border-card-border flex flex-col justify-between">
              <div>
                <h3 className="text-xl font-semibold mb-4 text-primary">
                  AMATravel.ca, AMA.AB.CA
                </h3>
                <p className="text-secondary mb-4 leading-relaxed">
                  At AMA, I started by implementing{" "}
                  <span className="italic">travel supplier microsites</span>
                  based on designs from the creative team, helping showcase each
                  partners' offerings.
                </p>
                <p className="text-secondary mb-4 leading-relaxed">
                  From there, I played a key role in our long-term{" "}
                  <span className="font-bold">Angular</span>
                  migration, moving from 1.x to 2+ and continuing to support
                  upgrades over the years.
                </p>
                <p className="text-secondary mb-4 leading-relaxed">
                  Eventually, our team took ownership of the main{" "}
                  <span className="italic">AMA website</span>, transitioning it
                  from WordPress to Angular and building new features like
                  online booking for registries and insurance.
                </p>
                <p className="text-secondary mb-4 leading-relaxed">
                  I also led the project that allowed integration between the
                  website and AMA's in-truck iPad app (D3), enabling users to
                  book tire swaps, battery tests, and other roadside services.
                  On top of that, I helped create custom interactive modules to
                  support one-off marketing campaigns like contests and raffles.
                </p>
              </div>

              <div>
                <div className="flex gap-2 mb-4">
                  <a
                    href="https://ama.ab.ca"
                    target="_blank"
                    rel="noopener noreferrer"
                    className="inline-flex items-center gap-2 border border-primary text-primary px-4 py-2 rounded-md hover:bg-primary hover:text-white transition-colors duration-200"
                  >
                    <FontAwesomeIcon
                      icon={faExternalLinkAlt}
                      className="w-4 h-4"
                    />
                    AMA
                  </a>
                  <a
                    href="https://www.amatravel.ca"
                    target="_blank"
                    rel="noopener noreferrer"
                    className="inline-flex items-center gap-2 border border-primary text-primary px-4 py-2 rounded-md hover:bg-primary hover:text-white transition-colors duration-200"
                  >
                    <FontAwesomeIcon
                      icon={faExternalLinkAlt}
                      className="w-4 h-4"
                    />
                    AMA Travel
                  </a>
                </div>

                <div className="flex flex-wrap gap-2 mb-4">
                  <TechPill tech={TechKey.TYPESCRIPT} />
                  <TechPill tech={TechKey.ANGULAR} />
                  <TechPill tech={TechKey.SASS} />
                  <TechPill tech={TechKey.CSHARP} />
                  <TechPill tech={TechKey.AZURE} />
                </div>

                <p className="text-sm text-muted">
                  Proprietary corporate software - code not available for public
                  viewing
                </p>
              </div>
            </div>

            {/* Pandell */}
            <div className="bg-card rounded-lg shadow-lg p-6 border border-card-border flex flex-col justify-between">
              <div>
                <h3 className="text-xl font-semibold mb-4 text-primary">
                  Pandell
                </h3>
                <p className="text-secondary mb-4 leading-relaxed">
                  At Pandell, I worked on{" "}
                  <span className="italic">land management software</span>{" "}
                  tailored for oil and gas clients, contributing to the
                  successful delivery of key features under tight deadlines.
                </p>
                <p className="text-secondary mb-4 leading-relaxed">
                  The platform leveraged{" "}
                  <span className="font-bold">SQL Spatial</span> and a highly
                  abstracted metadata-driven schema — with dynamic tables and
                  relationships stored in a meta-layer.
                </p>
                <p className="text-secondary mb-4 leading-relaxed">
                  Development followed a rigorous{" "}
                  <span className="italic">test-driven</span> approach, ensuring
                  reliability across a complex and evolving codebase.
                </p>
              </div>

              <div>
                <div className="flex flex-wrap gap-2 mb-4">
                  <TechPill tech={TechKey.TYPESCRIPT} />
                  <TechPill tech={TechKey.REACT} />
                  <TechPill tech={TechKey.CSHARP} />
                  <TechPill tech={TechKey.AZURE} />
                </div>
                <p className="text-sm text-muted">
                  Proprietary corporate software - code not available for public
                  viewing
                </p>
              </div>
            </div>
          </div>

          {/* Public Projects Section */}
          <h2 className="text-2xl md:text-3xl font-bold mb-6 text-primary">
            Open Source & Personal Projects
          </h2>
          <div className="grid gap-8 md:grid-cols-2 lg:grid-cols-2 max-w-7xl mx-auto mb-16">
            {projects.map((project, index) => (
              <div
                key={index}
                className="bg-card rounded-lg shadow-lg p-6 border border-card-border transition-all duration-300 hover:shadow-xl hover:-translate-y-1"
              >
                <h3 className="text-xl font-semibold mb-4 text-primary">
                  {project.title}
                </h3>
                <p className="text-secondary mb-6 leading-relaxed">
                  {project.description}
                </p>

                <div className="flex gap-4 flex-wrap">
                  {project.webLink && (
                    <a
                      href={project.webLink}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="inline-flex items-center gap-2 bg-accent text-white px-4 py-2 rounded-md hover:bg-accent-hover transition-colors duration-200"
                    >
                      <FontAwesomeIcon
                        icon={faExternalLinkAlt}
                        className="w-4 h-4"
                      />
                      View Project
                    </a>
                  )}
                  {project.githubLink && (
                    <a
                      href={project.githubLink}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="inline-flex items-center gap-2 border border-primary text-primary px-4 py-2 rounded-md hover:bg-primary hover:text-white transition-colors duration-200"
                    >
                      <FontAwesomeIcon icon={faGithub} className="w-4 h-4" />
                      GitHub
                    </a>
                  )}
                </div>
              </div>
            ))}
          </div>

          {/* Add More Projects Section */}
          <div className="mt-12 text-center">
            <div className="bg-card rounded-lg shadow-lg p-8 border border-card-border max-w-2xl mx-auto">
              <h2 className="text-2xl font-semibold mb-4 text-primary">
                More Projects Coming Soon
              </h2>
              <p className="text-secondary leading-relaxed">
                I'm always working on something new! Check back later or follow
                me on GitHub to see what I'm building next.
              </p>
            </div>
          </div>
        </section>
      </main>

      <Footer />
    </div>
  );
}
