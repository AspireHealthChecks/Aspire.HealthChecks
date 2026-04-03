---
layout: structured
title: Aspire HealthChecks
hero:
  eyebrow: "ASP.NET Core"
  title: "Health checks for services, dashboards, and Kubernetes workloads"
  lead: "Aspire.HealthChecks brings together a broad package catalog, the HealthChecks UI dashboard, and Kubernetes-focused tooling in one repository."
  primary_label: "Browse documentation"
  primary_url: /guides/
  secondary_label: "Open the reference manual"
  secondary_url: /reference/
  tags:
    - Packages
    - HealthChecks UI
    - Docker
    - Kubernetes
  code_title: "Install a package"
  code: "dotnet add package Aspire.HealthChecks.SqlServer"
  note_title: "Site layout"
  note_text: "The original repository articles now live under /docs and are published with GitHub Pages."
stats:
  - label: "Packages"
    value: "50+"
  - label: "Guides"
    value: "7"
  - label: "Focus areas"
    value: "UI, Docker, Kubernetes"
sections:
  - title: "Choose a path"
    description: "Start with the section that matches what you are trying to do."
    variant: cards
    columns: 3
    items:
      - title: "Documentation"
        description: "Read the migrated operational guides for UI, Docker, webhooks, and Kubernetes."
        url: /guides/
      - title: "Reference Manual"
        description: "Use copy-paste examples and practical usage notes for everyday integration work."
        url: /reference/
      - title: "News"
        description: "Track documentation updates and the historical UI changelog from one entry point."
        url: /news/
---

Aspire HealthChecks brings together a broad package catalog, the HealthChecks UI dashboard, and Kubernetes-focused tooling in one repository.

## Start here

- [Documentation]({{ '/guides/' | relative_url }}) for Docker, UI, webhook, and Kubernetes guides.
- [Reference Manual]({{ '/reference/' | relative_url }}) for copy-paste examples and operational notes.
- [News]({{ '/news/' | relative_url }}) for documentation updates and the UI changelog.

## Quick install

```bash
dotnet add package Aspire.HealthChecks.SqlServer
```

## Coverage

- 50+ health check packages for infrastructure and platform dependencies.
- HealthChecks UI guidance for dashboard deployment, branding, and notifications.
- Kubernetes articles for probes, operator deployment, and service discovery.
