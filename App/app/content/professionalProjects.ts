import { TechKey } from "./techData";

export interface ProfessionalProject {
  title: string;
  description: string;
  tech: TechKey[];
  ctas: {
    name: string;
    url: string;
  }[];
}

const professionalProjects: ProfessionalProject[] = [
  {
    title:
      "OneBridge/Irth: Cognitive Integrity Management (CIM)/Asset Integrity Management (AIM)",
    description:
      'At OneBridge / Irth Solutions I helped modernize a sprawling monorepo that housed both a legacy Angular 1.x application and a new cloud-first platform. I co-built the Control Panel MVP—an Angular (2+) front-end with a .NET Core + GraphQL API backed by SQL Server—that let pipeline operators manage users, facilities, and inline-inspection ("pig") reports while asynchronous processing ran through Azure Functions and Service Bus. After handing the MVP to an offshore team and launching the companion Vendor Portal, I shifted to building a shared component library/dev-kit (think Angular Material-style docs), hardening CI/CD, reviewing PRs, and mentoring devs—turning quick proof-of-concept code into a robust, documented, multi-app foundation.',
    tech: [TechKey.CSHARP, TechKey.ANGULAR, TechKey.AZURE, TechKey.GRAPHQL],
    ctas: [],
  },
  {
    title: "LAIKA: Various Production Apps",
    description:
      "At LAIKA, I worked across a wide tech stack—primarily React and Rust, but also Python (Django, Flask) and even Scala—building internal tools for stop-motion film production. Our backend data layer was handled entirely by ShotGrid, so each app was tailored to a specific department's workflow. My first major project was EOD (End of Days), an app used by assistant directors to log end-of-day notes about active stages and shots. I also helped transition the Big Boards scheduling tool from Scala to Rust/React, enabling schedulers to plan which shots would be filmed on which stages, by which animators, and with which support teams. These apps were highly collaborative and directly supported daily production operations across the studio. In addition to hands-on development, I also acted as the Agile team lead, helping prioritize work, unblock teammates, and keep projects on track.",
    tech: [
      TechKey.PYTHON,
      TechKey.REACT,
      TechKey.GRAPHQL,
      TechKey.DJANGO,
      TechKey.RUST,
    ],
    ctas: [],
  },
  {
    title: "AMATravel.ca, AMA.AB.CA",
    description:
      "At AMA, I started by implementing travel supplier microsites based on designs from the creative team, helping showcase each partners' offerings. From there, I played a key role in our long-term Angular migration, moving from 1.x to 2+ and continuing to support upgrades over the years. Eventually, our team took ownership of the main AMA website, transitioning it from WordPress to Angular and building new features like online booking for registries and insurance. I also contributed to the architecture that allowed integration between the website and AMA's in-truck iPad app (D3), enabling users to book tire swaps, battery tests, and other roadside services. On top of that, I helped create custom interactive modules to support one-off marketing campaigns like contests and raffles.",
    tech: [
      TechKey.TYPESCRIPT,
      TechKey.ANGULAR,
      TechKey.SASS,
      TechKey.CSHARP,
      TechKey.AZURE,
    ],
    ctas: [
      { name: "AMA", url: "https://ama.ab.ca" },
      { name: "AMA Travel", url: "https://www.amatravel.ca" },
    ],
  },
  {
    title: "Pandell: Land Management Software",
    description:
      "At Pandell, I worked on land management software tailored for oil and gas clients, contributing to the successful delivery of key features under tight deadlines. The platform leveraged SQL Spatial and a highly abstracted metadata-driven schema — with dynamic tables and relationships stored in a meta-layer. Development followed a rigorous test-driven approach, ensuring reliability across a complex and evolving codebase.",
    tech: [TechKey.TYPESCRIPT, TechKey.REACT, TechKey.CSHARP, TechKey.AZURE],
    ctas: [],
  },
];

export default professionalProjects;
