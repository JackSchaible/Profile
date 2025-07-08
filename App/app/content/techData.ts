export enum TechKey {
  // Languages
  TYPESCRIPT = "typescript",
  CSHARP = "csharp",
  PYTHON = "python",
  RUST = "rust",
  SASS = "sass",

  // Frameworks
  REACT = "react",
  ANGULAR = "angular",
  NEXTJS = "nextjs",
  NODEJS = "nodejs",
  FLASK = "flask",
  DJANGO = "django",

  // Cloud
  AZURE = "azure",
  AWS = "aws",

  // DevOps
  DOCKER = "docker",
  GITHUB_ACTIONS = "github-actions",
  AZURE_DEVOPS = "azure-devops",
  KUBERNETES = "kubernetes",

  // Other
  GRAPHQL = "graphql",
}

export interface TechData {
  name: string;
  img: string;
  color: string;
}

export const techLookup: Record<TechKey, TechData> = {
  [TechKey.TYPESCRIPT]: {
    name: "TypeScript",
    img: "/img/lang/ts.svg",
    color: "bg-blue-600",
  },
  [TechKey.CSHARP]: {
    name: "C#",
    img: "/img/lang/cs.svg",
    color: "bg-purple-600",
  },
  [TechKey.PYTHON]: {
    name: "Python",
    img: "/img/lang/py.svg",
    color: "bg-yellow-500",
  },
  [TechKey.RUST]: {
    name: "Rust",
    img: "/img/lang/rs.svg",
    color: "bg-orange-600",
  },
  [TechKey.SASS]: {
    name: "SASS",
    img: "/img/lang/sass.svg",
    color: "bg-pink-500",
  },
  [TechKey.REACT]: {
    name: "React",
    img: "/img/fwork/react.svg",
    color: "bg-blue-500",
  },
  [TechKey.ANGULAR]: {
    name: "Angular",
    img: "/img/fwork/ng.svg",
    color: "bg-red-600",
  },
  [TechKey.NEXTJS]: {
    name: "Next.js",
    img: "/img/fwork/next.svg",
    color: "bg-black",
  },
  [TechKey.NODEJS]: {
    name: "Node.js",
    img: "/img/fwork/nodejs.svg",
    color: "bg-green-600",
  },
  [TechKey.FLASK]: {
    name: "Flask",
    img: "/img/fwork/flask.svg",
    color: "bg-gray-600",
  },
  [TechKey.DJANGO]: {
    name: "Django",
    img: "/img/fwork/dj.svg",
    color: "bg-green-700",
  },
  [TechKey.AZURE]: {
    name: "Azure",
    img: "/img/cloud/az.svg",
    color: "bg-blue-600",
  },
  [TechKey.AWS]: {
    name: "AWS",
    img: "/img/cloud/aws.svg",
    color: "bg-orange-500",
  },
  [TechKey.DOCKER]: {
    name: "Docker",
    img: "/img/devops/docker.svg",
    color: "bg-blue-500",
  },
  [TechKey.GITHUB_ACTIONS]: {
    name: "GitHub Actions",
    img: "/img/devops/gh.svg",
    color: "bg-gray-800",
  },
  [TechKey.AZURE_DEVOPS]: {
    name: "Azure DevOps",
    img: "/img/devops/ado.svg",
    color: "bg-blue-600",
  },
  [TechKey.KUBERNETES]: {
    name: "Kubernetes",
    img: "/img/devops/k8s.svg",
    color: "bg-blue-700",
  },
  [TechKey.GRAPHQL]: {
    name: "GraphQL",
    img: "/img/devops/docker.svg",
    color: "bg-pink-600",
  },
};
