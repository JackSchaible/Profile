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
          
          {/* Public Projects Section */}
          <h2 className="text-2xl md:text-3xl font-bold mb-6 text-primary">
            Open Source & Personal Projects
          </h2>
          <div className="grid gap-8 md:grid-cols-2 lg:grid-cols-2 max-w-6xl mx-auto mb-16">
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
                      <FontAwesomeIcon icon={faExternalLinkAlt} className="w-4 h-4" />
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

          {/* Professional/Corporate Projects Section */}
          <h2 className="text-2xl md:text-3xl font-bold mb-6 text-primary">
            Professional & Corporate Projects
          </h2>
          <div className="grid gap-8 md:grid-cols-1 lg:grid-cols-2 max-w-6xl mx-auto mb-16">
            {/* OneBridge */}
            <div className="bg-card rounded-lg shadow-lg p-6 border border-card-border">
              <h3 className="text-xl font-semibold mb-4 text-primary">
                OneBridge/Irth: Cognitive Integrity Management (CIM)/Asset Integrity Management (AIM)
              </h3>
              <p className="text-secondary mb-4 leading-relaxed">
                At OneBridge / Irth Solutions I helped modernize a sprawling monorepo that housed both a legacy Angular 1.x application and a new cloud-first platform. I co-built the Control Panel MVP—an Angular (2+) front-end with a .NET Core + GraphQL API backed by SQL Server—that let pipeline operators manage users, facilities, and inline-inspection (“pig”) reports while asynchronous processing ran through Azure Functions and Service Bus. After handing the MVP to an offshore team and launching the companion Vendor Portal, I shifted to building a shared component library/dev-kit (think Angular Material-style docs), hardening CI/CD, reviewing PRs, and mentoring devs—turning quick proof-of-concept code into a robust, documented, multi-app foundation.
              </p>
              <div className="flex flex-wrap gap-2 mb-4">
                <TechPill tech={TechKey.CSHARP} />
                <TechPill tech={TechKey.ANGULAR} />
                <TechPill tech={TechKey.AZURE} />
                <TechPill tech={TechKey.GRAPHQL} />
              </div>
              <p className="text-sm text-muted">
                Proprietary corporate software - code not available for public viewing
              </p>
            </div>

            {/* LAIKA */}
            <div className="bg-card rounded-lg shadow-lg p-6 border border-card-border">
              <h3 className="text-xl font-semibold mb-4 text-primary">
                Various Apps
              </h3>
              <p className="text-secondary mb-4 leading-relaxed">
                At LAIKA, I worked across a wide tech stack—primarily React and Rust, but also Python (Django, Flask) and even Scala—building internal tools for stop-motion film production. Our backend data layer was handled entirely by ShotGrid, so each app was tailored to a specific department's workflow. My first major project was EOD (End of Days), an app used by assistant directors to log end-of-day notes about active stages and shots. I also helped transition the Big Boards scheduling tool from Scala to Rust/React, enabling schedulers to plan which shots would be filmed on which stages, by which animators, and with which support teams. These apps were highly collaborative and directly supported daily production operations across the studio. In addition to hands-on development, I also acted as the Agile team lead, helping prioritize work, unblock teammates, and keep projects on track.
              </p>
              <div className="flex flex-wrap gap-2 mb-4">
                <TechPill tech={TechKey.PYTHON} />
                <TechPill tech={TechKey.REACT} />
                <TechPill tech={TechKey.GRAPHQL} />
                <TechPill tech={TechKey.DJANGO} />
                <TechPill tech={TechKey.RUST} />
              </div>
              <p className="text-sm text-muted">
                Proprietary corporate software - code not available for public viewing
              </p>
            </div>

            {/* AMA */}
            <div className="bg-card rounded-lg shadow-lg p-6 border border-card-border">
              <h3 className="text-xl font-semibold mb-4 text-primary">
                AMATravel.ca, AMA.AB.CA
              </h3>
              <p className="text-secondary mb-4 leading-relaxed">
                At AMA, I started by implementing travel supplier microsites based on designs from the creative team, helping showcase each partner’s offerings. From there, I played a key role in our long-term Angular migration, moving from 1.x to 2+ and continuing to support upgrades over the years. Eventually, our team took ownership of the main AMA website, transitioning it from WordPress to Angular and building new features like online booking for registries and insurance. I also contributed to the architecture that allowed integration between the website and AMA's in-truck iPad app (D3), enabling users to book tire swaps, battery tests, and other roadside services. On top of that, I helped create custom interactive modules to support one-off marketing campaigns like contests and raffles.
              </p>
              <div className="flex flex-wrap gap-2 mb-4">
                <TechPill tech={TechKey.TYPESCRIPT} />
                <TechPill tech={TechKey.ANGULAR} />
                <TechPill tech={TechKey.SASS} />
                <TechPill tech={TechKey.CSHARP} />
                <TechPill tech={TechKey.AZURE} />
              </div>
              <p className="text-sm text-muted">
                Proprietary corporate software - code not available for public viewing
              </p>
            </div>

            {/* Pandell */}
            <div className="bg-card rounded-lg shadow-lg p-6 border border-card-border">
              <h3 className="text-xl font-semibold mb-4 text-primary">
                Pandell
              </h3>
              <p className="text-secondary mb-4 leading-relaxed">
                At Pandell, I worked on land management software tailored for oil and gas clients, contributing to the successful delivery of key features under tight deadlines. The platform leveraged SQL Spatial and a highly abstracted metadata-driven schema — with dynamic tables and relationships stored in a meta-layer. Development followed a rigorous test-driven approach, ensuring reliability across a complex and evolving codebase.
              </p>
              <div className="flex flex-wrap gap-2 mb-4">
                <TechPill techcolor="bg-gray-400" />
                <TechPill name="Framework" color="bg-gray-400" />
                <TechPill name="Tools" color="bg-gray-400" />
              </div>
              <p className="text-sm text-muted">
                Proprietary corporate software - code not available for public viewing
              </p>
            </div>
          </div>
          
          {/* Add More Projects Section */}
          <div className="mt-12 text-center">
            <div className="bg-card rounded-lg shadow-lg p-8 border border-card-border max-w-2xl mx-auto">
              <h2 className="text-2xl font-semibold mb-4 text-primary">
                More Projects Coming Soon
              </h2>
              <p className="text-secondary leading-relaxed">
                I'm always working on something new! Check back later or follow me on GitHub to see what I'm building next.
              </p>
            </div>
          </div>
        </section>
      </main>

      <Footer />
    </div>
  );
}
