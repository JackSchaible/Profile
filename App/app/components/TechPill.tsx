import Image from "next/image";
import { TechKey, techLookup } from "../content/techData";

interface TechPillProps {
  tech?: TechKey;
  name?: string;
  img?: string;
  color?: string;
  size?: "sm" | "md";
}

export default function TechPill({ tech, name, img, color, size = "sm" }: TechPillProps) {
  const sizeClasses = {
    sm: "px-3 py-1 text-sm",
    md: "px-4 py-2 text-base"
  };

  // If tech key is provided, use data from lookup
  const techData = tech ? techLookup[tech] : null;
  const displayName = techData?.name || name || "Unknown";
  const displayImg = techData?.img || img;
  const displayColor = techData?.color || color;

  const pillClasses = displayImg 
    ? "inline-flex items-center gap-2 bg-badge text-badge rounded-full font-medium border border-badge"
    : `inline-flex items-center rounded-full font-medium text-white ${displayColor || "bg-gray-500"}`;

  return (
    <span className={`${pillClasses} ${sizeClasses[size]}`}>
      {displayImg && (
        <Image
          src={displayImg}
          alt={displayName + " logo"}
          width={size === "sm" ? 16 : 20}
          height={size === "sm" ? 16 : 20}
          className="inline"
        />
      )}
      {displayName}
    </span>
  );
}
