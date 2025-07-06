import { TechKey } from "./techData";

const techStack = [
  {
    category: "Languages",
    items: [
      TechKey.TYPESCRIPT,
      TechKey.CSHARP,
      TechKey.PYTHON,
      TechKey.RUST,
      TechKey.SASS,
    ],
  },
  {
    category: "Frameworks",
    items: [
      TechKey.REACT,
      TechKey.ANGULAR,
      TechKey.NEXTJS,
      TechKey.NODEJS,
      TechKey.FLASK,
      TechKey.DJANGO,
    ],
  },
  {
    category: "Cloud",
    items: [TechKey.AZURE, TechKey.AWS],
  },
  {
    category: "DevOps",
    items: [
      TechKey.AZURE_DEVOPS,
      TechKey.DOCKER,
      TechKey.GITHUB_ACTIONS,
      TechKey.KUBERNETES,
    ],
  },
];
export default techStack;
