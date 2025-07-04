"use client";

import { useEffect } from "react";
import { useRouter } from "next/navigation";

export default function Contact() {
  const router = useRouter();

  useEffect(() => {
    router.replace("/under-construction");
  }, [router]);

  return null;
}
